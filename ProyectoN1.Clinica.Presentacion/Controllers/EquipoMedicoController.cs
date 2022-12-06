using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoN1.Clinica.Entidades;
using ProyectoN1.Clinica.LogicaNegocio;

namespace ProyectoN1.Clinica.Presentacion.Controllers
{
    public class EquipoMedicoController : Controller
    {
        // GET: EquipoMedico
        public ActionResult Index()
        {
            return View(AdministradorEquipoMedico.Listar());
        }

        public ActionResult Create()
        {
            ViewBag.Clinicas = AdministradorClinica.Listar();
            ViewBag.Especialidades = AdministradorClinica.ListarEspecialidad(1);
            EquipoMedico vEquipo = new EquipoMedico();
            return View(vEquipo);
        }

        [HttpPost]
        public ActionResult Create(EquipoMedico pModelo)
        {
            try
            {
                AdministradorEquipoMedico.AgregarEquipoMedico(pModelo);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetEspecialidad(int val)
        {
            if (val != 0)
            {
                List<TipoEspecialidad> vEspecialidades = AdministradorClinica.ListarEspecialidad(val);
                return Json(vEspecialidades, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = "false" });
        }
    }
}