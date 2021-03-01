using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class ProductoBL
    {
        Contexto _contexto;
        public List<Producto> listadeProductos { get; set; }

        public ProductoBL()
        {
            _contexto = new Contexto();
            listadeProductos = new List<Producto>();

        }
        public List<Producto> ObtenerProductos()
        {
            listadeProductos= _contexto.Productos
            .Include("Categoria")
            .ToList();
            return listadeProductos;
        }
        public void GuardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productoexistente = _contexto.Productos.Find(producto.Id);
                productoexistente.Descripcion = producto.Descripcion;
                productoexistente.Precio = producto.Precio;
            }
            _contexto.SaveChanges();
          
        }

           
     

        public  Producto ObtenerProductos (int id)
        {
            var producto = _contexto.Productos.Find(id);
            return producto;
        }
        public void EliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);
            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }

    }
}
