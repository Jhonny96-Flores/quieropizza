using Almacen.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Quinto Avance


namespace ALMACEN.WebAdmin.Controllers
{
    public class SolicitudAduanaController : Controller
    {
        SolicitudAduanaBL _SolicitudAduanaBL;
        ClientesBL _ClientesBL;

        public SolicitudAduanaController()
        {
            _SolicitudAduanaBL = new SolicitudAduanaBL();
            _ClientesBL = new ClientesBL();
        }
        // GET: SolicitudAduana
        public ActionResult Index()
        {
            var listadeSolicitudes = _SolicitudAduanaBL.ObtenerSolicitudes();
            return View(listadeSolicitudes);
        }
        public ActionResult Crear()
        {
            var nuevaSolicitud = new SolicitudAduana();

            var clientes = _ClientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(nuevaSolicitud);
        }

        [HttpPost]
        public ActionResult Crear(SolicitudAduana SolicitudAduana)
        {
            if (ModelState.IsValid)
            {
                if (SolicitudAduana.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un Cliente");
                    return View(SolicitudAduana);
                }

                _SolicitudAduanaBL.GuardarSolicitud(SolicitudAduana);

                return RedirectToAction("Index");

            }
            var clientes = _ClientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(SolicitudAduana);

        }
        public ActionResult Editar(int id)
        {
            var Solicitud = _SolicitudAduanaBL.ObtenerSolicitud(id);
            var Clientes = _ClientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(Clientes, "Id", "Nombre", Solicitud.ClienteId);
            return View(Solicitud);
        }
        [HttpPost]
        public ActionResult Editar(SolicitudAduana SolicitudAduana)
        {
            if (ModelState.IsValid)
            {
                if (SolicitudAduana.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un Cliente");
                    return View(SolicitudAduana);
                }

                _SolicitudAduanaBL.GuardarSolicitud(SolicitudAduana);

                return RedirectToAction("Index");

            }
            var clientes = _ClientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre", SolicitudAduana.ClienteId);

            return View(SolicitudAduana);

        }
        public ActionResult Detalle(int id)
        {
            var Solicitud = _SolicitudAduanaBL.ObtenerSolicitud(id);
            return View(Solicitud);
        }
    }
}