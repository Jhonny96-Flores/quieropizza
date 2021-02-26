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
        public List<Producto> ListadeProductos { get; set; }

        public ProductoBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();

        }
        public List<Producto> ObtenerProductos()
        {
            ListadeProductos= _contexto.Productos.ToList();
            return ListadeProductos;
        }
    }
}
