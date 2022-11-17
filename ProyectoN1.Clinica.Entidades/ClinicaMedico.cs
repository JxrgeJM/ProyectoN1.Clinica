using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoN1.Clinica.Entidades
{
    public  class ClinicaMedico
    {
        public ClinicaMedico()
        {
            IdClinica = 0;
            Medico = new Medico();
        }

        public ClinicaMedico(int idClinica, Medico medico)
        {
            IdClinica = idClinica;
            Medico = medico;
        }

        [Required(ErrorMessage = "Requerido")]
        public int IdClinica { get; set; }

        [Display(Name = "Médico")]
        [Required(ErrorMessage = "Requerido")]
        public Medico Medico { get; set; }
    }
}
