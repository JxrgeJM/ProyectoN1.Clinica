using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoN1.Clinica.Entidades
{
    public class Medico
    {
        public Medico()
        {
            Id = 0;
            Nombre = "";
            Especialidad = new TipoEspecialidad();
        }

        public Medico(int id, string nombre, TipoEspecialidad especialidad)
        {
            Id = id;
            Nombre = nombre;
            Especialidad = especialidad;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public TipoEspecialidad Especialidad { get; set; }
    }
}
