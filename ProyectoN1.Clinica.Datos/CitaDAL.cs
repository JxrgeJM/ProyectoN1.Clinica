using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyectoN1.Clinica.Entidades;

namespace ProyectoN1.Clinica.Datos
{
    public class CitaDAL
    {
        public static List<Cita> Listar(int pIdClinica, DateTime pFecha)
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarCitas", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pIdClinica", pIdClinica);
            vCmd.Parameters.AddWithValue("@pDia", pFecha);
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<Cita> vDatos = new List<Cita>();
                while (vRd.Read())
                {
                    vDatos.Add(
                        new Cita()
                        {
                            Id = vRd.GetInt32(0),
                            Clinica = new Entidades.Clinica() { Id = vRd.GetInt32(1), Numero = vRd.GetString(2), Nombre = vRd.GetString(3) },
                            Especialidad = new TipoEspecialidad() { Id = vRd.GetInt32(4), Descripcion = vRd.GetString(5) },
                            Paciente = new Paciente() { Identificacion = vRd.GetString(6), Nombre = vRd.GetString(7), Telefono = vRd.GetInt32(8) },
                            Medico = new Medico() { Id = vRd.GetInt32(9), Nombre = vRd.GetString(10), Especialidad = new TipoEspecialidad() },
                            Fecha = vRd.GetDateTime(11),
                            Hora = vRd.GetInt32(12),
                            Monto = vRd.GetDecimal(13)
                        });
                }
                vRd.Close();
                return vDatos;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexion.getCnxClinica().Close();
            }
        }

        public static void Agregar(Cita pCita)
        {
            SqlCommand vCmd = new SqlCommand("SP_AgregarCita", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pClinica", pCita.Clinica.Id);
            vCmd.Parameters.AddWithValue("@pEspecialidad", pCita.Especialidad.Id);
            vCmd.Parameters.AddWithValue("@pPaciente", pCita.Paciente.Identificacion);
            vCmd.Parameters.AddWithValue("@pMedico", pCita.Medico.Id);
            vCmd.Parameters.AddWithValue("@pDia", pCita.Fecha);
            vCmd.Parameters.AddWithValue("@pHora", pCita.Hora);
            vCmd.Parameters.AddWithValue("@pMonto", pCita.Monto);
            try
            {
                Conexion.getCnxClinica().Open();
                vCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexion.getCnxClinica().Close();
            }
        }

        public static bool CitaDisponible(Cita pCita)
        {
            SqlCommand vCmd = new SqlCommand("SP_CitaDisponible", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pIdMedico", pCita.Medico.Id);
            vCmd.Parameters.AddWithValue("@pDia", pCita.Fecha);
            vCmd.Parameters.AddWithValue("@pHora", pCita.Hora);
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                int vCantidad = 0;
                if (vRd.Read())
                {
                    vCantidad = vRd.GetInt32(0);
                }
                vRd.Close();
                return vCantidad == 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexion.getCnxClinica().Close();
            }
        }

        public static bool CitaDisponibleConsultorio(Cita pCita)
        {
            SqlCommand vCmd = new SqlCommand("SP_CitaDisponibleConsultorio", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pIdClinica", pCita.Clinica.Id);
            vCmd.Parameters.AddWithValue("@pDia", pCita.Fecha);
            vCmd.Parameters.AddWithValue("@pHora", pCita.Hora);
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                int vCantidad = 0;
                if (vRd.Read())
                {
                    vCantidad = vRd.GetInt32(0);
                }
                vRd.Close();
                return vCantidad == 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexion.getCnxClinica().Close();
            }
        }
    }
}
