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
    public class ClinicaDAL
    {
        public static List<Entidades.Clinica> Listar()
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarClinicas", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<Entidades.Clinica> vDatos = new List<Entidades.Clinica>();
                while (vRd.Read())
                    vDatos.Add(new Entidades.Clinica(vRd.GetInt32(0), vRd.GetString(1), vRd.GetString(2)));
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

        public static void Modificar(Entidades.Clinica pClinica)
        {
            SqlCommand vCmd = new SqlCommand("SP_ModificarClinica", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pId", pClinica.Id);
            vCmd.Parameters.AddWithValue("@pNumero", pClinica.Numero);
            vCmd.Parameters.AddWithValue("@pNombre", pClinica.Nombre);
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

        public static void AgregarEspecialidad(int pIdClinica, int pIdEspecialidad)
        {
            SqlCommand vCmd = new SqlCommand("SP_AgregarClinicaEspecialidad", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pClinica", pIdClinica);
            vCmd.Parameters.AddWithValue("@pEspecialidad", pIdEspecialidad);
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

        public static void BorrarEspecialidad(int pIdClinica, int pIdEspecialidad)
        {
            SqlCommand vCmd = new SqlCommand("SP_BorrarClinicaEspecialidad", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pClinica", pIdClinica);
            vCmd.Parameters.AddWithValue("@pEspecialidad", pIdEspecialidad);
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

        public static List<TipoEspecialidad> ListarEspecialidad(int pIdClinica)
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarClinicaEspecialidad", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pClinica", pIdClinica);
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<TipoEspecialidad> vDatos = new List<TipoEspecialidad>();
                while (vRd.Read())
                    vDatos.Add(new TipoEspecialidad(vRd.GetInt32(0), vRd.GetString(1)));
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
