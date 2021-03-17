using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Quinto Avance
namespace Almacen.BL
{
    public class Clientes
    {
        public Clientes()
        {
            Activo = false;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre de Cliente")]
        [MinLength(2, ErrorMessage = "Ingrese minimo 2 caracteres")]
        [MaxLength(30, ErrorMessage = "Ingrese un maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Numero telefonico")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese Direccion")]
        public string Direccion { get; set; }

        public bool Activo { get; set; }
    }
}
