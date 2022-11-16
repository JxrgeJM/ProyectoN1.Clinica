using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.LogicaNegocio;

namespace ProyectoN1.Clinica.Presentacion.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            List<Medico> vLista =  AdministradorMedico.Listar();
            return View(vLista);
        }

        public ActionResult Create()
        {
            ViewBag.Especialidades = AdministradorTipoEspecialidad.Listar();
            return View(new Medico());
        }

        [HttpPost]
        public ActionResult Create(Medico pModelo)
        {
            if (ModelState.IsValid)
            {
                AdministradorMedico.Agregar(pModelo);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}