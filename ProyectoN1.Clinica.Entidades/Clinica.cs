using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoN1.Clinica.Entidades
{
    public class Clinica
    {
        public Clinica()
        {
            Id = 0;
            Nombre = "";
        }

        public Clinica(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }    
    }
}
