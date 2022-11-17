using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoN1.Clinica.Entidades.Reportes
{
    public class RepAtencionMedico
    {
        public RepAtencionMedico()
        {
            Medico = new Medico();
            CantidadCitas = 0;
            PorcentajeAtencion = 0;
        }

        public RepAtencionMedico(Medico medico, int cantidadCitas, int porcentajeAtencion)
        {
            Medico = medico;
            CantidadCitas = cantidadCitas;
            PorcentajeAtencion = porcentajeAtencion;
        }

        [Display(Name = "Médico")]
        public Medico Medico { get; set; }

        [Display(Name = "Cantidad de citas")]
        public int CantidadCitas { get; set; }

        [Display(Name = "Porcentaje de atención")]
        public int PorcentajeAtencion { get; set; }

    }
}
