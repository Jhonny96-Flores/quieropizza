using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" 
        + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ALMACENDB.mdf") 
        {  

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //Quinto Avance
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<SolicitudAduana> SolicitudAduana { get; set; }
        public DbSet<DetalleSolicitud> DetalleSolicitud { get; set; }


    }
}
