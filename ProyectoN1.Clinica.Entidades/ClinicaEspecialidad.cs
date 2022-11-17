using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoN1.Clinica.Entidades
{
    public class ClinicaEspecialidad
    {
        public ClinicaEspecialidad()
        {
            IdClinica = 0;
            Especialidad = new TipoEspecialidad();
        }

        public ClinicaEspecialidad(int idClinica, TipoEspecialidad especialidad)
        {
            IdClinica = idClinica;
            Especialidad = especialidad;
        }

        public int IdClinica { get; set; }

        public TipoEspecialidad Especialidad { get; set; }

    }
}
