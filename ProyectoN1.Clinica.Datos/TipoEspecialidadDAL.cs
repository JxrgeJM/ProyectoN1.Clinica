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
    public class TipoEspecialidadDAL
    {
        public static List<TipoEspecialidad> Listar()
        {
            SqlCommand vCmd = new SqlCommand("SP_ListarTipoEspecialidad", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.getCnxClinica().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<TipoEspecialidad> vDatos = new List<TipoEspecialidad>();
                while (vRd.Read())
                    vDatos.Add(new TipoEspecialidad(vRd.GetInt32(0), vRd.GetString(1).ToUpper()));
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
