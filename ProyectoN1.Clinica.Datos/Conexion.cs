using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoN1.Clinica.Datos
{
    public class Conexion
    {
        private static SqlConnection _cnxClinica = null;
        public static SqlConnection getCnxClinica()
        {
            if (_cnxClinica == null)
                _cnxClinica = new SqlConnection(ConfigurationManager.ConnectionStrings["CnxClinica"].ConnectionString);
            return _cnxClinica;
        }
    }
}
