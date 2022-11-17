using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoN1.Clinica.Datos;
using ProyectoN1.Clinica.Entidades;

namespace ProyectoN1.Clinica.LogicaNegocio
{
    public class AdministradorCita
    {
        public static List<Cita> Listar(int pIdClinica, DateTime pFecha)
        {
            return CitaDAL.Listar(pIdClinica, pFecha);
        }

        public static void Agregar(Cita pCita)
        {
            CitaDAL.Agregar(pCita);
        }
    }
}
