using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoN1.Clinica.Entidades.Reportes
{
    public class RepIngresos
    {
        public RepIngresos()
        {
            Clinica = new Clinica();
            CantidadCitas = 0;
            Ingresos = 0;
        }

        public RepIngresos(Clinica clinica, int cantidadCitas, decimal ingresos)
        {
            Clinica = clinica;
            CantidadCitas = cantidadCitas;
            Ingresos = ingresos;
        }

        public Clinica Clinica { get; set; }

        [Display(Name = "Cantidad de citas")]
        public int CantidadCitas { get; set; }

        public decimal Ingresos { get; set; }
    }
}
