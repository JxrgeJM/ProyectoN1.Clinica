using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "Requerido")] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public TipoEspecialidad Especialidad { get; set; }
    }
}
