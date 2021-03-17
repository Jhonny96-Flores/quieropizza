using Almacen.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


//Quinto Avance
namespace ALMACEN.WebAdmin.Controllers
{
    public class DetalleSolicitudController : Controller
    {
        SolicitudAduanaBL _SolicitudAduanaBL;
        ServiciosBL _ServiciosBL;

        public DetalleSolicitudController()
        {
            _SolicitudAduanaBL = new SolicitudAduanaBL();
            _ServiciosBL = new ServiciosBL();


        }

        // GET: DetalleSolicitud
        public ActionResult Index(int id)
        {
            var solicitud = _SolicitudAduanaBL.ObtenerSolicitud(id);
            solicitud.ListaDetalleSolicitud = _SolicitudAduanaBL.ObtenerdetSolicitud(id);
            return View(solicitud);
        }


        public ActionResult Crear(int id)
        {
            var nuevaDetSolicitud = new DetalleSolicitud();

            nuevaDetSolicitud.SolicitudId = id;

            var servicios = _ServiciosBL.ObtenerServicios();

            ViewBag.ServicioId = new SelectList(servicios, "Id", "Descripcion");

            return View(nuevaDetSolicitud);
        }

        [HttpPost]
        public ActionResult Crear(DetalleSolicitud detalleSolicitud)
        {
            if (ModelState.IsValid)
            {
                if (detalleSolicitud.ServicioId == 0)
                {
                    ModelState.AddModelError("ServicioId", "Seleccione un Servicio");
                    return View(detalleSolicitud);
                }

                _SolicitudAduanaBL.GuardardetSolicitud(detalleSolicitud);

                return RedirectToAction("Index", new { id = detalleSolicitud.SolicitudId });

            }
            var servicios = _ServiciosBL.ObtenerServicios();

            ViewBag.ServicioId = new SelectList(servicios, "Id", "Nombre");

            return View(detalleSolicitud);

        }

        public ActionResult Eliminar(int id)
        {
            var detalleSolicitud = _SolicitudAduanaBL.ObtenerSolicitudID(id);
            return View(detalleSolicitud);
        }
        [HttpPost]
        public ActionResult Eliminar(DetalleSolicitud DetalleSolicitud)
        {
            _SolicitudAduanaBL.EliminarDetalleSolicitud(DetalleSolicitud.Id);

            return RedirectToAction("Index", new { id = DetalleSolicitud.SolicitudId });
        }
    }
}