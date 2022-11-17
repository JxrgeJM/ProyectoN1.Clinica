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
    public class PacienteDAL
    {
        public static void Agregar(Paciente pPaciente)
        {
            SqlCommand vCmd = new SqlCommand("SP_AgregarPaciente", Conexion.getCnxClinica());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pId", pPaciente.Identificacion);
            vCmd.Parameters.AddWithValue("@pNombre", pPaciente.Nombre.ToUpper());
            vCmd.Parameters.AddWithValue("@pTelefono", pPaciente.Telefono);
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
