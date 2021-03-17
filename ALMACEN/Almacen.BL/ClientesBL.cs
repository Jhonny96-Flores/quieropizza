using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Quinto Avance
namespace Almacen.BL
{
    public class ClientesBL
    {

        Contexto _contexto;
        public List<Clientes> ListadeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new List<Clientes>();
        }

        public List<Clientes> ObtenerClientes()
        {
            ListadeClientes = _contexto.Clientes.ToList();

            return ListadeClientes;
        }


        public void GuardarClientes(Clientes clientes)
        {

            if (clientes.Id == 0)
            {
                _contexto.Clientes.Add(clientes);
            }
            else
            {
                var clientesExistente = _contexto.Clientes.Find(clientes.Id);
                clientesExistente.Nombre = clientes.Nombre;
                clientesExistente.Telefono = clientes.Telefono;
                clientesExistente.Direccion = clientes.Direccion;
                clientesExistente.Activo = clientes.Activo;
            }

            _contexto.SaveChanges();
        }

        public Clientes ObtenerClientes(int id)
        {
            var clientes = _contexto.Clientes.FirstOrDefault(p => p.Id == id);

            return clientes;
        }

        public void EliminarClientes(int Id)
        {
            var clientes = _contexto.Clientes.Find(Id);

            _contexto.Clientes.Remove(clientes);

            _contexto.SaveChanges();

        }

    }
}
