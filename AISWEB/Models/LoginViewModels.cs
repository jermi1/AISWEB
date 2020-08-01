using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AISWEB.Models
{
    public class LoginViewModels
    {

        // Para enlazar las propiedades de tipo modelo
        [BindProperty]
        public InputModel Input { get; set; }
        //Para almacenar datos temporalmente dentro de la propiedad errormensaje
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress(ErrorMessage = "Dirección de correo electronico no valida")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "La contraseña tiene al menos 6 caracteres", MinimumLength = 6)]
            public string Password { get; set; }
        }
    }
}
