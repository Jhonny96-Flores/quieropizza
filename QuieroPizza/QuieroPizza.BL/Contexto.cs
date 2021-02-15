using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base("QuieroPizzaDB")
        {
                
        }
        public DbSet<Producto> Productos { get; set; }
    }
}
