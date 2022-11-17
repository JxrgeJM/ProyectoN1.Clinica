using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.Entidades.Reportes;

namespace ProyectoN1.Clinica.Datos
{
    public class ReportesDAL
    {
        public static List<Paciente> ListarPacientesAtendidos(int pIdClinica)
        {
            SqlCommand vCmd = new SqlCommand("SP_RepPacientesAtendidos", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pIdClinica", pIdClinica);
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<Paciente> vDatos = new List<Paciente>();
                while (vRd.Read())
                    vDatos.Add(new Paciente(vRd.GetString(0), vRd.GetString(1), vRd.GetInt32(2)));
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

        public static List<Medico> ListarMedicosQueAtienden(int pIdClinica)
        {
            SqlCommand vCmd = new SqlCommand("SP_RepMedicoAtiende", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pIdClinica", pIdClinica);
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<Medico> vDatos = new List<Medico>();
                while (vRd.Read())
                    vDatos.Add(new Medico(vRd.GetInt32(0), vRd.GetString(1), new TipoEspecialidad() { Id = vRd.GetInt32(2), Descripcion = vRd.GetString(3) }));
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

        public static List<Cita> ListarCitasAtendidas(int pIdClinica, DateTime pFecha)
        {
            SqlCommand vCmd = new SqlCommand("SP_RepCitasAtendidas", Conexion.getCnxClinica());
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

        public static List<RepIngresos> ListarClinicasIngreso()
        {
            SqlCommand vCmd = new SqlCommand("SP_RepClinicasIngresos", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<RepIngresos> vDatos = new List<RepIngresos>();
                while (vRd.Read())
                    vDatos.Add(new RepIngresos(new Entidades.Clinica(vRd.GetInt32(0), vRd.GetString(1), vRd.GetString(2)), vRd.GetInt32(3), vRd.GetDecimal(4)));
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

        public static List<RepAtencionMedico> ListarAtencionMedico()
        {
            SqlCommand vCmd = new SqlCommand("SP_RepPorcentajeAtencionMedico", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<RepAtencionMedico> vDatos = new List<RepAtencionMedico>();
                while (vRd.Read())
                    vDatos.Add(new RepAtencionMedico(new Medico(vRd.GetInt32(0), vRd.GetString(1), new TipoEspecialidad(vRd.GetInt32(2), vRd.GetString(3))), vRd.GetInt32(4), vRd.GetInt32(5) ));
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

        public static List<RepAtencionEspecialidad> ListarAtencionEspecialidad()
        {
            SqlCommand vCmd = new SqlCommand("SP_RepPorcentajeAtencionEspecialidad", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<RepAtencionEspecialidad> vDatos = new List<RepAtencionEspecialidad>();
                while (vRd.Read())
                    vDatos.Add(new RepAtencionEspecialidad(new TipoEspecialidad(vRd.GetInt32(0), vRd.GetString(1).ToUpper()), vRd.GetInt32(2), vRd.GetInt32(3)));
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
    }
}
