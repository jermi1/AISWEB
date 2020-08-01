using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AISWEB.Controllers
{
    // [Route("/Error")]
    public class ErrorController : Controller
    {
        public IActionResult NoExistePagina(int? statusCode = null)
        {
            if (statusCode.HasValue) 
            {
                if (statusCode.Value == 500) 
                {
                    // sirve para poder almacenar informacion del lado del servidor
                    ViewData["Error"] = statusCode.ToString();
                    ViewData["Men2"] = "Hacemos un seguimiento de estos errores automáticamente, pero si el problema persiste, no dude en contactarnos. Mientras tanto, intente refrescarse";
                    ViewData["Mensaje"] = "Error Interno del Servidor";
                }
                if ( statusCode.Value == 404)
                {
                    ViewData["Error"] = statusCode.ToString();
                    ViewData["Mensaje"] = "Lo sentimos pero no se pudo encontrar esta página";
                    ViewData["Men2"] = "La página que busca no existe";
                }
            }
            return View();
        }
    }
}