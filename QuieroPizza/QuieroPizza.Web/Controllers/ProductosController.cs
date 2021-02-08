using QuieroPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizza.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var Producto = new ProductoModel();
            Producto.id = 1;
            Producto.descripcion = "Pizza 6 quesos";

            return View(Producto);
        }
    }
}