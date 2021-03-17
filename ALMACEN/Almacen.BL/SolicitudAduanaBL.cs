
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Quinto Avance
namespace Almacen.BL
{
    public class SolicitudAduanaBL
    {
        Contexto _contexto;
        public List<SolicitudAduana> ListadeSolicitudes { get; set; }
        public SolicitudAduanaBL()
        {
            _contexto = new Contexto();
            ListadeSolicitudes = new List<SolicitudAduana>();

        }
        public List<SolicitudAduana> ObtenerSolicitudes()
        {
            ListadeSolicitudes = _contexto.SolicitudAduana.Include("Cliente").ToList();

            return ListadeSolicitudes;

        }

        public List<DetalleSolicitud> ObtenerdetSolicitud(int SolicitudId)
        {
            var listadetSolicitud = _contexto.DetalleSolicitud.Include("Servicio").Where(o => o.SolicitudId == SolicitudId).ToList();
            return listadetSolicitud;
        }

        public DetalleSolicitud ObtenerSolicitudID(int id)
        {
            var DetalleSolicitud = _contexto.DetalleSolicitud
                .Include("Servicio").FirstOrDefault(p => p.Id == id);

            return DetalleSolicitud;
        }

        public SolicitudAduana ObtenerSolicitud(int id)
        {
            var solicitud = _contexto.SolicitudAduana.Include("Cliente").FirstOrDefault(p => p.Id == id);

            return solicitud;
        }


        public void GuardarSolicitud(SolicitudAduana SolicitudAduana)
        {
            if (SolicitudAduana.Id == 0)
            {
                _contexto.SolicitudAduana.Add(SolicitudAduana);
            }
            else
            {
                var SolicitudExistente = _contexto.SolicitudAduana.Find(SolicitudAduana.Id);

                SolicitudExistente.ClienteId = SolicitudAduana.ClienteId;
                SolicitudAduana.Activo = SolicitudAduana.Activo;
            }

            _contexto.SaveChanges();
        }

        public void GuardardetSolicitud(DetalleSolicitud detalleSolicitud)
        {
            var servicio = _contexto.Servicios.Find(detalleSolicitud.ServicioId);

            detalleSolicitud.Precio = servicio.Precio;
            if (detalleSolicitud.ServicioId == 2)
            {
                detalleSolicitud.Total = detalleSolicitud.Precio * detalleSolicitud.Cantidad * detalleSolicitud.Estadia;

            }
            else
            {
                detalleSolicitud.Total = detalleSolicitud.Precio;
            }

            var solicitud = _contexto.SolicitudAduana.Find(detalleSolicitud.SolicitudId);

            solicitud.Total = solicitud.Total + detalleSolicitud.Total;

            _contexto.DetalleSolicitud.Add(detalleSolicitud);
            _contexto.SaveChanges();
        }
        public void EliminarDetalleSolicitud(int id)
        {
            var detalleSolicitud = _contexto.DetalleSolicitud.Find(id);
            _contexto.DetalleSolicitud.Remove(detalleSolicitud);

            var solicitud = _contexto.SolicitudAduana.Find(detalleSolicitud.SolicitudId);
            solicitud.Total = detalleSolicitud.Total - detalleSolicitud.Total;

            _contexto.SaveChanges();
        }

    }
}