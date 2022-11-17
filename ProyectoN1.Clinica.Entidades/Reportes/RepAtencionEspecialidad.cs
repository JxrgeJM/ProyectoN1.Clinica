using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoN1.Clinica.Entidades.Reportes
{
    public class RepAtencionEspecialidad
    {
        public RepAtencionEspecialidad()
        {
            Especialidad = new TipoEspecialidad();
            CantidadCitas = 0;
            PorcentajeAtencion = 0;
        }

        public RepAtencionEspecialidad(TipoEspecialidad especialidad, int cantidadCitas, int porcentajeAtencion)
        {
            Especialidad = especialidad;
            CantidadCitas = cantidadCitas;
            PorcentajeAtencion = porcentajeAtencion;
        }

        public TipoEspecialidad Especialidad { get; set; }

        [Display(Name = "Cantidad de citas")]
        public int CantidadCitas { get; set; }

        [Display(Name = "Porcentaje de atención")]
        public int PorcentajeAtencion { get; set; }
    }
}
