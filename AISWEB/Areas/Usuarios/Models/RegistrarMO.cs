using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AISWEB.Areas.Usuarios.Models
{
    public class RegistrarMO
    {

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo nid es obligatorio.")]
        public string NID { get; set; }

        [Required(ErrorMessage = "El campo telefono es obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato telefono ingresado no es válido.")]
        public string Telefono { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo correo electrónico no es una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        //[DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Rol { get; set; }
        public string ID { get; set; }

    }
}
