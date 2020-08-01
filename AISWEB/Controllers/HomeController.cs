using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AISWEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using AISWEB.Library;
using Newtonsoft.Json;
using AISWEB.Areas.Principal.Controllers;
using Microsoft.AspNetCore.Http;
using AISWEB.Data;

namespace AISWEB.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController(IServiceProvider serviceProvider)
        //{
        // //   CrearRoles(serviceProvider);
        //}
        private LLUsuarios _usuarios;

        private SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _usuarios = new LLUsuarios(userManager, signInManager, roleManager, context);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inautorizado()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModels model)
        {

            if (ModelState.IsValid)
            {
                  List<object[]> listObject = await _usuarios.UsuarioLogin(model.Input.Email, model.Input.Password);
                  object[] objects = listObject[0];
                  var _identityError = (IdentityError)objects[0];
                  model.ErrorMessage = _identityError.Description;
                if (model.ErrorMessage.Equals("True"))
                {
                    //var data = JsonConvert.SerializeObject(objects[1]);
                    //HttpContext.Session.SetString("Usuario",data);
                    return RedirectToAction(nameof(PrincipalController.Index), "Principal");
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private async Task CrearRoles(IServiceProvider serviceProvider) 
        //{
        //    // Creando servicio para poder obtener los roles y Usuarios de la bd
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        //    String[] rolesNombres = { "Administrador", "Coordinador", "Auxiliar" };
        //    foreach (var item in rolesNombres)
        //    {
        //        var existeRol = await roleManager.RoleExistsAsync(item);
        //        if (!existeRol) 
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(item));
        //        }
        //    }
        //}
    }
}
