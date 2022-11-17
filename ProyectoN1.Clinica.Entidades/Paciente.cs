using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "Requerido")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Requerido")]
        public int Telefono { get; set; }
    }
}
