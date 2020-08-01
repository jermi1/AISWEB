using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AISWEB.Areas.Usuarios.Models;
using AISWEB.Areas.Usuarios.Pages;
using AISWEB.Controllers;
using AISWEB.Data;
using AISWEB.Library;
using AISWEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AISWEB.Areas.Usuarios.Controllers
{
    [Authorize]
    [Area("Usuarios")]
    public class UsuariosController : Controller
    {
        private ListObject listObject = new ListObject();
        // private readonly SignInManager<IdentityUser> _signInManager;
        private LUsuarios _user;
        private static DataPaginador<RegistrarMO> model;
        private LLUsuarios usuarios;


        public UsuariosController(
            SignInManager<IdentityUser> _signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context) 
        {
            listObject._signInManager = _signInManager;
            listObject._userManager = userManager;
            listObject._usuarios = new LLUsuarios(userManager, _signInManager, roleManager, context);
            //usuarios = new LLUsuarios();

        }
        public IActionResult Usuarios(int id, String filtrar, int registros)
        {
            if (listObject._signInManager.IsSignedIn(User))
            {
                // ViewData["Roles"] = usuarios.UsuarioDatos(HttpContext);
                Object[] objects = new Object[3];
                var data = listObject._usuarios.getUsuariosAsync(filtrar, 0);
                if (0 < data.Result.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new Paginador<RegistrarMO>().paginador(data.Result,
                        id, registros, "Usuarios", "Usuarios", "Usuarios", url);
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<RegistrarMO>();
                }
                model = new DataPaginador<RegistrarMO>
                {
                    List = (List<RegistrarMO>)objects[2],
                    Pagi_info = (String)objects[0],
                    Pagi_navegacion = (String)objects[1],
                    Input = new RegistrarMO(),
                };
                return View(model);
            }
            else 
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            HttpContext.Session.Remove("Usuario");
            await listObject._signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}