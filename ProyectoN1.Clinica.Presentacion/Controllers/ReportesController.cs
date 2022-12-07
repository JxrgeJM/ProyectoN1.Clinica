using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
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
            ViewBag.Clinicas = AdministradorClinica.Listar();
            List<Paciente> vModelo = AdministradorReportes.ListarPacientesAtendidos(pIdClinica);
            return View(vModelo);
        }

        public ActionResult MedicosQueAtendieron(int pIdClinica = 1)
        {
            ViewBag.Clinicas = AdministradorClinica.Listar();
            List<Medico> vModelo = AdministradorReportes.ListarMedicosQueAtienden(pIdClinica);
            return View(vModelo);
        }

        public ActionResult CitasAtendidas(int pIdClinica = 1)
        {
            ViewBag.Clinicas = AdministradorClinica.Listar();
            List<Cita> vModelo = AdministradorReportes.ListarCitasAtendidas(pIdClinica);
            return View(vModelo);
        }

        public ActionResult EspecialidadesPorClinica(int pIdClinica = 1)
        {
            ViewBag.Clinicas = AdministradorClinica.Listar();
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

        public ActionResult ReporteActivos(int pIdClinica = 1)
        {
            ViewBag.Clinicas = AdministradorClinica.Listar();
            List<EquipoMedico> vModelo = AdministradorEquipoMedico.Listar().Where(p => p.Clinica.Id == pIdClinica).ToList();
            return View(vModelo);
        }

        #region ArchivosJSON

        public FileStreamResult PacientesAtendidosJSON(int pIdClinica = 1)
        {
            List<Paciente> vModelo = AdministradorReportes.ListarPacientesAtendidos(pIdClinica);
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "PacientesAtendidos.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult MedicosQueAtendieronJSON(int pIdClinica = 1)
        {
            List<Medico> vModelo = AdministradorReportes.ListarMedicosQueAtienden(pIdClinica);
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "MedicosQueAtendieron.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult CitasAtendidasJSON(int pIdClinica = 1)
        {
            List<Cita> vModelo = AdministradorReportes.ListarCitasAtendidas(pIdClinica);
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "CitasAtendidas.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult EspecialidadesPorClinicaJSON(int pIdClinica = 1)
        {
            List<TipoEspecialidad> vModelo = AdministradorReportes.ListarEspecialidadesClinica(pIdClinica);
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "EspecialidadesPorClinica.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult ReporteDeIngresoJSON()
        {
            List<RepIngresos> vModelo = AdministradorReportes.ListarClinicasIngreso();
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "IngresoPorClinica.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult Estadisticas1JSON()
        {
            List<RepAtencionMedico> vModelo = AdministradorReportes.ListarAtencionMedico();
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "AtencionPorMedico.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult Estadisticas2JSON()
        {
            List<RepAtencionEspecialidad> vModelo = AdministradorReportes.ListarAtencionEspecialidad();
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "AtencionPorEspecialidad.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        public FileStreamResult ActivosJSON(int pIdClinica = 1)
        {
            List<EquipoMedico> vModelo = AdministradorEquipoMedico.Listar().Where(p => p.Clinica.Id == pIdClinica).ToList();
            var vJSON = JsonConvert.SerializeObject(vModelo);
            var fileName = "Activos.json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(vJSON);
            var content = new System.IO.MemoryStream(bytes);
            return File(content, "application/json", fileName);
        }

        #endregion
    }
}