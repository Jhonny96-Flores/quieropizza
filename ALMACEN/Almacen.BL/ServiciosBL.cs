using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.BL
{
    public class ServiciosBL
    {
        Contexto _contexto;
        public List<Servicio> ListadeServicios { get; set; }

        public ServiciosBL()
        {
            _contexto = new Contexto();
            ListadeServicios = new List<Servicio>();
        }

        public List<Servicio> ObtenerServicios()
        {
            ListadeServicios = _contexto.Servicios.Include("Categoria").ToList();

            return ListadeServicios;
        }


        public void GuardarServicio(Servicio servicio)
        {

            if (servicio.Id == 0)
            {
                _contexto.Servicios.Add(servicio);
            }
            else
            {
                var productoExistente = _contexto.Servicios.Find(servicio.Id);

                productoExistente.Descripcion = servicio.Descripcion;
                productoExistente.CategoriaId = servicio.CategoriaId;
                productoExistente.Precio = servicio.Precio;
                productoExistente.UrlImagen = servicio.UrlImagen;
            }

            _contexto.SaveChanges();
        }

        public Servicio ObtenerServicio(int id)
        {
            var servicio = _contexto.Servicios.Include("Categoria").FirstOrDefault(p => p.Id == id);

            return servicio;
        }

        public void EliminarServicio(int Id)
        {
            var servicio = _contexto.Servicios.Find(Id);

            _contexto.Servicios.Remove(servicio);

            _contexto.SaveChanges();
            
        }

    }
}
