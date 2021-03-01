﻿using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizza.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductoBL _productosBL;
        CategoriasBL _categoriasBL;
       

        public ProductosController()
        {
            _productosBL = new ProductoBL();
            _categoriasBL = new CategoriasBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();
            return View(listadeProductos);

        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            var nuevacategoria = _categoriasBL.ObtenerCategorias();

            ViewBag.listadeCategorias = new SelectList(nuevacategoria, "Id", "Descripcion");




            return View(nuevoProducto);
        }
        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _productosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProductos(id);
           return View(producto);
        }
        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            _productosBL.GuardarProducto(producto);
            var nuevacategoria = _categoriasBL.ObtenerCategorias();

            ViewBag.listadeCategorias = new SelectList(nuevacategoria, "Id", "Descripcion",producto.categoriaId);


            return RedirectToAction("Index");
        }
        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProductos(id);
            return View(producto);
        }
        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProductos(id);
            return View(producto);
        }
        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}