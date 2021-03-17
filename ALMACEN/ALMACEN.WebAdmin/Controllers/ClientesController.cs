using Almacen.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Quinto Avance
namespace ALMACEN.WebAdmin.Controllers
{
    public class ClientesController : Controller
    {
        ClientesBL _clientesBL;

        public ClientesController()
        {

            _clientesBL = new ClientesBL();
        }


        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clientesBL.ObtenerClientes();

            return View(listadeClientes);
        }

        public ActionResult Crear()
        {
            var nuevoCliente = new Clientes();


            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                if (clientes.Nombre != clientes.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre de Cliente", "Contiene espacios, Inicie de nuevo");
                    return View(clientes);
                }

                _clientesBL.GuardarClientes(clientes);

                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        public ActionResult Editar(int id)

        {

            var clientes = _clientesBL.ObtenerClientes(id);

            return View(clientes);
        }

        [HttpPost]
        public ActionResult Editar(Clientes clientes)
        {


            if (ModelState.IsValid)
            {
                if (clientes.Nombre != clientes.Nombre.Trim())
                {
                    ModelState.AddModelError("Descripcion", "");

                    return View(clientes);
                }


                _clientesBL.GuardarClientes(clientes);

                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        public ActionResult Detalle(int id)
        {
            var clientes = _clientesBL.ObtenerClientes(id);

            return View(clientes);
        }

        public ActionResult Eliminar(int id)
        {
            var clientes = _clientesBL.ObtenerClientes(id);

            return View(clientes);
        }

        [HttpPost]

        public ActionResult Eliminar(Clientes clientes)
        {
            _clientesBL.EliminarClientes(clientes.Id);

            return RedirectToAction("Index");
        }
    }
}