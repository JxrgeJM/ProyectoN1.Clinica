using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.LogicaNegocio;

namespace ProyectoN1.Clinica.Presentacion.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index(int pIdClinica = 1)
        {
            ViewBag.Clinicas = AdministradorClinica.Listar();
            List<Cita> vCitas = AdministradorCita.Listar(pIdClinica, DateTime.Now);
            return View(vCitas);
        }

        public ActionResult AgregarCita(int pIdClinica)
        {
            List<Entidades.Clinica> vClinicas = AdministradorClinica.Listar();
            List<TipoEspecialidad> vEspecialidades = AdministradorClinica.ListarEspecialidad(pIdClinica);
            ViewBag.Medicos = AdministradorMedico.ListarPorClinica(pIdClinica).Where(p => p.Especialidad.Id == vEspecialidades.FirstOrDefault().Id);
            ViewBag.Especialidades = vEspecialidades;
            ViewBag.Clinicas = vClinicas;

            Cita vCita = new Cita() { Clinica = vClinicas.Where(p => p.Id == pIdClinica).FirstOrDefault(), Fecha = DateTime.Now};
            return View(vCita);
        }

        [HttpPost]
        public ActionResult AgregarCita(Cita pModelo)
        {
            try
            {
                AdministradorPaciente.Agregar(pModelo.Paciente);
            }
            catch (Exception){}

            string vMensaje = "";
            if ((pModelo.Hora >= 800 && pModelo.Hora < 1200) || (pModelo.Hora >= 1330 && pModelo.Hora < 1700))
            {
                if (AdministradorCita.CitaDisponibleConsultorio(pModelo))
                {
                    if (AdministradorCita.CitaDisponible(pModelo))
                        AdministradorCita.Agregar(pModelo);
                    else
                        vMensaje = "El especialista no tiene espacio a la hora seleccionada.";
                }
                else
                    vMensaje = "Consultorio no disponible en la fecha y hora indicada.";
            }
            else
            {
                vMensaje = "No se puede agendar en horario de almuerzo o no laboral.";
            }

            if (vMensaje != "")
            {
                ViewBag.Message = vMensaje;
                ViewBag.Clinicas = AdministradorClinica.Listar();
                ViewBag.Especialidades = AdministradorClinica.ListarEspecialidad(pModelo.Clinica.Id);
                ViewBag.Medicos = AdministradorMedico.ListarPorClinica(pModelo.Clinica.Id).Where(p => p.Especialidad.Id == pModelo.Especialidad.Id);
                return View(pModelo);
            }

            return RedirectToAction("Index", new { pIdClinica = pModelo.Clinica.Id });
        }


        public ActionResult GetEspecialidad(int pIdClinica)
        {
            if (pIdClinica != 0)
            {
                List<TipoEspecialidad> vEspecialidades = AdministradorClinica.ListarEspecialidad(pIdClinica);
                return Json(vEspecialidades, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = "false" });
        }

        public ActionResult GetMedicos(int pIdClinica, int pIdEspecialidad)
        {
            if (pIdClinica != 0)
            {
                List<Medico> vMedicos = AdministradorMedico.ListarPorClinica(pIdClinica).Where(p => p.Especialidad.Id == pIdEspecialidad).ToList();
                return Json(vMedicos, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = "false" });
        }

    }
}