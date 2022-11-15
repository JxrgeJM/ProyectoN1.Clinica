using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoN1.Clinica.Entidades
{
    public class Paciente
    {
        public Paciente()
        {
            Identificacion = "";
            Nombre = "";
            Telefono = 0;
        }

        public Paciente(string identificacion, string nombre, int telefono)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Telefono = telefono;
        }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public int Telefono { get; set; }
    }
}
