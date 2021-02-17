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
            return _contexto.Productos.ToList(); 
        }
    }
}
