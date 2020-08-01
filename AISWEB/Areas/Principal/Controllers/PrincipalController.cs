using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AISWEB.Controllers;
using AISWEB.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AISWEB.Areas.Principal.Controllers
{
    [Authorize]
    [Area("Principal")]
    public class PrincipalController : Controller
    {
        
        private LLUsuarios usuarios;
        private SignInManager<IdentityUser> _signInManager;

        public PrincipalController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            usuarios = new LLUsuarios();
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                //ViewData["Roles"] = usuarios.UsuarioDatos(HttpContext);
                return View();
            }
            else 
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

        }
    }
}