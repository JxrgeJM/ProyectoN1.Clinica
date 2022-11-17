using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.Entidades.Reportes;
using ProyectoN1.Clinica.LogicaNegocio;

namespace ProyectoN1.Clinica.Presentacion.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PacientesAtendidos(int pIdClinica = 1)
        {
            List<Paciente> vModelo = AdministradorReportes.ListarPacientesAtendidos(pIdClinica);
            return View(vModelo);
        }

        public ActionResult MedicosQueAtendieron(int pIdClinica = 1)
        {
            List<Medico> vModelo = AdministradorReportes.ListarMedicosQueAtienden(pIdClinica);
            return View(vModelo);
        }

        public ActionResult CitasAtendidas(int pIdClinica = 1)
        {
            List<Cita> vModelo = AdministradorReportes.ListarCitasAtendidas(pIdClinica);
            return View(vModelo);
        }

        public ActionResult EspecialidadesPorClinica(int pIdClinica = 1)
        {
            List<TipoEspecialidad> vModelo = AdministradorReportes.ListarEspecialidadesClinica(pIdClinica);
            return View(vModelo);
        }

        public ActionResult ReporteDeIngreso()
        {
            List<RepIngresos> vModelo = AdministradorReportes.ListarClinicasIngreso();
            return View(vModelo);
        }

        public ActionResult Estadisticas1()
        {
            List<RepAtencionMedico> vModelo = AdministradorReportes.ListarAtencionMedico();
            return View(vModelo);
        }

        public ActionResult Estadisticas2()
        {
            List<RepAtencionEspecialidad> vModelo = AdministradorReportes.ListarAtencionEspecialidad();
            return View(vModelo);
        }

    }
}