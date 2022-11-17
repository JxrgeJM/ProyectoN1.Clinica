using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoN1.Clinica.Entidades
{
    public class Cita
    {
        public Cita()
        {
            Id = 0;
            Clinica = new Clinica();
            Especialidad = new TipoEspecialidad();
            Paciente = new Paciente();
            Medico = new Medico();
            Fecha = new DateTime();
            Hora = 0;
            Monto = 0;
        }

        public Cita(int id, Clinica clinica, TipoEspecialidad especialidad, Paciente paciente, Medico medico, DateTime fecha, int hora, decimal monto)
        {
            Id = id;
            Clinica = clinica;
            Especialidad = especialidad;
            Paciente = paciente;
            Medico = medico;
            Fecha = fecha;
            Hora = hora;
            Monto = monto;
        }

        public int Id { get; set; }

        public Clinica Clinica { get; set; }

        public TipoEspecialidad Especialidad { get; set; }

        public Paciente Paciente { get; set; }

        [Display(Name = "Médico")]
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public int Hora { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public decimal Monto { get; set; }
    }
}
