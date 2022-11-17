using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoN1.Clinica.Datos;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.Entidades.Reportes;

namespace ProyectoN1.Clinica.LogicaNegocio
{
    public class AdministradorReportes
    {
        public static List<Paciente> ListarPacientesAtendidos(int pIdClinica)
        {
            return ReportesDAL.ListarPacientesAtendidos(pIdClinica);
        }

        public static List<Medico> ListarMedicosQueAtienden(int pIdClinica)
        {
            return ReportesDAL.ListarMedicosQueAtienden(pIdClinica);
        }

        public static List<Cita> ListarCitasAtendidas(int pIdClinica)
        {
            return ReportesDAL.ListarCitasAtendidas(pIdClinica, DateTime.Now);
        }

        public static List<TipoEspecialidad> ListarEspecialidadesClinica(int pIdClinica)
        {
            return ClinicaDAL.ListarEspecialidad(pIdClinica);
        }

        public static List<RepIngresos> ListarClinicasIngreso()
        {
            return ReportesDAL.ListarClinicasIngreso();
        }

        public static List<RepAtencionMedico> ListarAtencionMedico()
        {
            return ReportesDAL.ListarAtencionMedico();
        }

        public static List<RepAtencionEspecialidad> ListarAtencionEspecialidad()
        {
            return ReportesDAL.ListarAtencionEspecialidad();
        }
    }
}
