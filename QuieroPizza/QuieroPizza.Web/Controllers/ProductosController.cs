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
            var Producto1 = new ProductoModel();
            Producto1.id = 1;
            Producto1.descripcion = "Pizza 6 quesos";

            var Producto2 = new ProductoModel();
            Producto2.id = 2;
            Producto2.descripcion = "Pizza 4 Estaciones";

            var Producto3 = new ProductoModel();
            Producto3.id = 3;
            Producto3.descripcion = "Pizza Jamon y queso";

            var listadeProducto = new List<ProductoModel>();
            listadeProducto.Add(Producto1);
            listadeProducto.Add(Producto2);
            listadeProducto.Add(Producto3);
            return View(listadeProducto);
        }
    }
}