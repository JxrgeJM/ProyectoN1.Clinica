using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public Cita(int id, Clinica clinica, TipoEspecialidad especialidad, Paciente paciente, Medico medico, DateTime fecha, int hora)
        {
            Id = id;
            Clinica = clinica;
            Especialidad = especialidad;
            Paciente = paciente;
            Medico = medico;
            Fecha = fecha;
            Hora = hora;
        }

        public int Id { get; set; }

        public Clinica Clinica { get; set; }

        public TipoEspecialidad Especialidad { get; set; }

        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }

        public DateTime Fecha { get; set; }

        public int Hora { get; set; }
    }
}
