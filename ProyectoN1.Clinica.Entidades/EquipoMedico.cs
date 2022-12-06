using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoN1.Clinica.Entidades
{
    public class EquipoMedico
    {
        public EquipoMedico()
        {
            Activo = "";
            Nombre = "";
            Serie = "";
            Descripcion = "";
            FechaCompra = DateTime.Now;
            Especialidad = new TipoEspecialidad();
            Clinica = new Clinica();
        }

        public EquipoMedico(string activo, string nombre, string serie, string descripcion, 
            DateTime fechaCompra, TipoEspecialidad especialidad, Clinica clinica)
        {
            Activo = activo;
            Nombre = nombre;
            Serie = serie;
            Descripcion = descripcion;
            FechaCompra = fechaCompra;
            Especialidad = especialidad;
            Clinica = clinica;
        }

        [Required(ErrorMessage = "Requerido")]
        public string Activo { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public DateTime FechaCompra { get; set; }

        public TipoEspecialidad Especialidad { get; set; }

        public Clinica Clinica { get; set; }

    }
}
