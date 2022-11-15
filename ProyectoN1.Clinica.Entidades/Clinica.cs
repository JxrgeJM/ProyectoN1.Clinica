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
            Numero = "";
        }

        public Clinica(int id, string numero, string nombre)
        {
            Id = id;
            Numero = numero;
            Nombre = nombre;
        }

        public int Id { get; set; }

        public string Numero { get; set; }

        public string Nombre { get; set; }    
    }
}
