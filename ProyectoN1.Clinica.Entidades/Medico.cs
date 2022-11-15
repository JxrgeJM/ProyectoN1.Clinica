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
            Name = "";
            Especialidad = new TipoEspecialidad();
        }

        public Medico(int id, string name, TipoEspecialidad especialidad)
        {
            Id = id;
            Name = name;
            Especialidad = especialidad;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public TipoEspecialidad Especialidad { get; set; }
    }
}
