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
        // GET: Clinica
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


    }
}