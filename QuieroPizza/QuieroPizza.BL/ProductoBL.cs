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
     

        public ProductoBL()
        {
            _contexto = new Contexto();

        }
        public List<Producto> ObtenerProductos()
        {
            _contexto.Productos.ToList();

            var Producto1 = new Producto();
            Producto1.Id = 1;
            Producto1.Descripcion = "Pizza 6 quesos";
            Producto1.Precio = 200;

            var Producto2 = new Producto();
            Producto2.Id = 2;
            Producto2.Descripcion = "Pizza 4 Estaciones";
            Producto2.Precio = 250;

            var Producto3 = new Producto();
            Producto3.Precio = 180;
            Producto3.Id = 3;
            Producto3.Descripcion = "Pizza Jamon y queso ";

            var listadeProducto = new List<Producto>();
            listadeProducto.Add(Producto1);
            listadeProducto.Add(Producto2);
            listadeProducto.Add(Producto3);


            return listadeProducto;
        }
    }
}
