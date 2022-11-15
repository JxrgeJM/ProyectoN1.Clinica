using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoN1.Clinica.Datos;
using ProyectoN1.Clinica.Entidades;

namespace ProyectoN1.Clinica.LogicaNegocio
{
    public class AdministradorPaciente
    {
        public static void Agregar(Paciente pPaciente)
        {
            PacienteDAL.Agregar(pPaciente);
        }
    }
}
