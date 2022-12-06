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
    public class EquipoMedicoDAL
    {
        public static List<EquipoMedico> Listar()
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarEquipoMedico", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<EquipoMedico> vDatos = new List<EquipoMedico>();
                while (vRd.Read())
                    vDatos.Add(new EquipoMedico(vRd.GetString(0), vRd.GetString(1), vRd.GetString(2), vRd.GetString(3), vRd.GetDateTime(4), 
                        new TipoEspecialidad(), 
                        new Entidades.Clinica()));
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

        public static void AgregarEquipoMedico(EquipoMedico pEquipoMedico)
        {
            SqlCommand vCmd = new SqlCommand("SP_AgregarEquipoMedico", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pNumActivo", pEquipoMedico.Activo);
            vCmd.Parameters.AddWithValue("@pNombre", pEquipoMedico.Nombre);
            vCmd.Parameters.AddWithValue("@pSerie", pEquipoMedico.Serie);
            vCmd.Parameters.AddWithValue("@pDescripcion", pEquipoMedico.Descripcion);
            vCmd.Parameters.AddWithValue("@pFechaCompra", pEquipoMedico.FechaCompra);
            vCmd.Parameters.AddWithValue("@pIdEspecialidad", pEquipoMedico.Especialidad.Id);
            vCmd.Parameters.AddWithValue("@pIdClinica", pEquipoMedico.Clinica.Id);
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
