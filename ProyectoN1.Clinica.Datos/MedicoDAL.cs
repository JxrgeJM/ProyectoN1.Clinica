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
        public static void Agregar(Medico pMedico)
        {
            SqlCommand vCmd = new SqlCommand("SP_AgregarMedico", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pId", pMedico.Id);
            vCmd.Parameters.AddWithValue("@pNombre", pMedico.Nombre);
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
