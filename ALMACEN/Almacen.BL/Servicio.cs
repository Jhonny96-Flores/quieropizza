using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.BL
{
    public class Servicio
    {
        public Servicio()
        {
            Activo = true;
        }

        //Entrega 4 se agregaron condiciones descripcion, precio, se agrego imagen


        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese Descripcion")]
        [MinLength(2, ErrorMessage = "Ingrese minimo 2 caracter")]
        [MaxLength(30, ErrorMessage = "Ingrese maximo 30 caracter")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese Precio")]
        [Range(0, 1000, ErrorMessage = "Ingrese precio 0 y 1000")]
        public double Precio { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }

    }
}
