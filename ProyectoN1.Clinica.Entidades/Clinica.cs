using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }    
    }
}
