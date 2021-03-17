using Almacen.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALMACEN.WebAdmin.Controllers
{
     
    public class ServiciosController : Controller
    {
        ServiciosBL _serviciosBL;
        CategoriasBL _categoriasBL;

        public ServiciosController()
        {
            _serviciosBL = new ServiciosBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Servicios
        public ActionResult Index()
        {
            var listadeServicios = _serviciosBL.ObtenerServicios();

            return View(listadeServicios);
        }

        public ActionResult Crear()
        {
            var nuevoServicio = new Servicio();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoServicio);
        }

        // Entrega 4 se modifico Crear y editar

        [HttpPost]

        public ActionResult Crear(Servicio servicio, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (servicio.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(servicio);
                }

                if (imagen != null)
                {
                    servicio.UrlImagen = GuardarImagen(imagen);
                }

                _serviciosBL.GuardarServicio(servicio);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(servicio);
        }

        public ActionResult Editar(int id)
        {
            var producto = _serviciosBL.ObtenerServicio(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Servicio servicio, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (servicio.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(servicio);
                }

                if (imagen != null)
                {
                    servicio.UrlImagen = GuardarImagen(imagen);
                }

                _serviciosBL.GuardarServicio(servicio);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(servicio);
        }

        public ActionResult Detalle(int id)
        {
            var servicio = _serviciosBL.ObtenerServicio(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            return View(servicio);
        }

        public ActionResult Eliminar(int id)
        {
            var servicio = _serviciosBL.ObtenerServicio(id);

            return View(servicio);
        }

        [HttpPost]

        public ActionResult Eliminar(Servicio servicio)
        {
            _serviciosBL.EliminarServicio(servicio.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }

    }
}