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
        public static void Agregar(Cita pCita)
        {
            CitaDAL.Agregar(pCita);
        }
    }
}
