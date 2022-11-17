using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.LogicaNegocio;

namespace ProyectoN1.Clinica.Presentacion.Controllers
{
    public class ClinicaController : Controller
    {

        #region CLINICAS

        public ActionResult Index()
        {
            List<Entidades.Clinica> vLista = AdministradorClinica.Listar();
            return View(vLista);
        }

        public ActionResult Edit(int pId)
        {
            Entidades.Clinica vClinica = AdministradorClinica.Listar().Where(p => p.Id == pId).FirstOrDefault();
            return View(vClinica);
        }

        [HttpPost]
        public ActionResult Edit(Entidades.Clinica pModelo)
        {
            try
            {
                if (ModelState.IsValid)
                    AdministradorClinica.Modificar(pModelo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #endregion

        #region ESPECIALIDADES

        public ActionResult Especialidades(int pIdClinica)
        {
            ViewBag.Clinica = AdministradorClinica.Listar().Where(p => p.Id == pIdClinica).FirstOrDefault();
            List<TipoEspecialidad> vEspecialidades = AdministradorClinica.ListarEspecialidad(pIdClinica);
            return View(vEspecialidades);
        }

        public ActionResult AgregarEspecialidad(int pIdClinica)
        {
            ViewBag.Especialidades = AdministradorTipoEspecialidad.Listar();
            ClinicaEspecialidad vClinicaEspecialidad = new ClinicaEspecialidad() { IdClinica = pIdClinica };
            return View(vClinicaEspecialidad);
        }

        [HttpPost]
        public ActionResult AgregarEspecialidad(ClinicaEspecialidad pModelo)
        {
            AdministradorClinica.AgregarEspecialidad(pModelo);
            return RedirectToAction("Especialidades", new { pIdClinica = pModelo.IdClinica });
        }

        public ActionResult QuitarEspecialidad(int pIdClinica, int pIdEspecialidad)
        {
            AdministradorClinica.BorrarEspecialidad(new ClinicaEspecialidad() { IdClinica= pIdClinica, Especialidad = new TipoEspecialidad() { Id = pIdEspecialidad} });
            return RedirectToAction("Especialidades", new { pIdClinica = pIdClinica });
        }

        #endregion

        #region MEDICOS

        public ActionResult Medicos(int pIdClinica)
        {
            ViewBag.Clinica = AdministradorClinica.Listar().Where(p => p.Id == pIdClinica).FirstOrDefault();
            List<Medico> vMedicos = AdministradorMedico.ListarPorClinica(pIdClinica);
            return View(vMedicos);
        }

        public ActionResult AgregarMedico(int pIdClinica)
        {
            ViewBag.Clinica = AdministradorClinica.Listar().Where(p => p.Id == pIdClinica).FirstOrDefault();
            ViewBag.MedicosDisponibles = AdministradorMedico.ListarDisponibles(pIdClinica);
            ClinicaMedico vClinicaMedico = new ClinicaMedico() { IdClinica = pIdClinica, Medico = new Medico() };
            return View(vClinicaMedico);
        }

        [HttpPost]
        public ActionResult AgregarMedico(ClinicaMedico pModelo)
        {
            AdministradorClinica.AgregarMedicoEspecialista(pModelo);
            return RedirectToAction("Medicos", new { pIdClinica = pModelo.IdClinica });
        }

        #endregion



    }
}