using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Quinto Avance
namespace Almacen.BL
{
    public class SolicitudAduana
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public List<DetalleSolicitud> ListaDetalleSolicitud { get; set; }
        public SolicitudAduana()
        {
            Activo = true;
            Fecha = DateTime.Now;

            ListaDetalleSolicitud = new List<DetalleSolicitud>();
        }
    }
    public class DetalleSolicitud
    {
        public int Id { get; set; }
        public int SolicitudId { get; set; }
        public SolicitudAduana Solicitud { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        public int Cantidad { get; set; }
        public int Estadia { get; set; }
        public string Espacio { get; set; }
        public int Anchura { get; set; }
        public int Altura { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

    }
}

