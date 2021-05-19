using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prestamos.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} esta vacio.")]
        [StringLength(60)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} esta vacio.")]
        [StringLength(60)]
        public String Apellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} esta vacio.")]
        [StringLength(60)]
        public String Direccion { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}