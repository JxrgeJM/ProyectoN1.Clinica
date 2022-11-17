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
    public class MedicoDAL
    {
        public static List<Medico> Listar()
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarMedicos", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
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

        public static List<Medico> ListarPorClinica(int pIdClinica)
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarMedicosPorClinica", Conexion.getCnxClinica());
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

        public static List<Medico> ListarDisponibles(int pIdClinica)
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarMedicosDisponibles", Conexion.getCnxClinica());
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

        public static void Agregar(Medico pMedico)
        {
            SqlCommand vCmd = new SqlCommand("SP_AgregarMedico", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pId", pMedico.Id);
            vCmd.Parameters.AddWithValue("@pNombre", pMedico.Nombre.ToUpper());
            vCmd.Parameters.AddWithValue("@pEspecialidad", pMedico.Especialidad.Id);
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


    }
}
