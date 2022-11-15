using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoN1.Clinica.Entidades
{
    public class TipoEspecialidad
    {
        public TipoEspecialidad()
        {
            Id = 0;
            Descripcion = "";
        }

        public TipoEspecialidad(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}
