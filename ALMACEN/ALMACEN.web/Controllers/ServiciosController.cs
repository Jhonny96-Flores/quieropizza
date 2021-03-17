using Almacen.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALMACEN.web.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            var serviciosBL = new ServiciosBL();
            var listaServicios = serviciosBL.ObtenerServicios();


            return View(listaServicios);
        }
    }
}