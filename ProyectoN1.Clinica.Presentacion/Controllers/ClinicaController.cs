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

            return View();
        }
    }
}