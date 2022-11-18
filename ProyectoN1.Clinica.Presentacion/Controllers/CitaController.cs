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
            ViewBag.Especialidades = AdministradorTipoEspecialidad.Listar();
            ViewBag.Medicos = AdministradorMedico.ListarPorClinica(pIdClinica);
            Entidades.Clinica vClinica = AdministradorClinica.Listar().Where(p => p.Id == pIdClinica).FirstOrDefault();
            Cita vCita = new Cita() { Clinica = vClinica, Fecha = DateTime.Now};
            return View(vCita);
        }

        [HttpPost]
        public ActionResult AgregarCita(Cita pModelo)
        {
            try
            {
                AdministradorPaciente.Agregar(pModelo.Paciente);
            }
            catch (Exception)
            {
            }
            if ((pModelo.Hora>=800 && pModelo.Hora < 1200) || (pModelo.Hora >= 1330 && pModelo.Hora < 1700))
            {
                AdministradorCita.Agregar(pModelo);
            }
            else
            {
                //tirar advertencia
            }
            return RedirectToAction("Index", new { pIdClinica = pModelo.Clinica.Id });
        }

    }
}