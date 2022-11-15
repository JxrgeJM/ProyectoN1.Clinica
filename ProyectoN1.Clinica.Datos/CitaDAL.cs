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
