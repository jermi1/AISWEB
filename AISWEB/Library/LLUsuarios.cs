using AISWEB.Areas.Usuarios.Models;
using AISWEB.Data;
using AISWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISWEB.Library
{
    public class LLUsuarios : ListObject
    {
        public LLUsuarios()
        {

        }
        public LLUsuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _usersRole = new UsuariosRoles();
        }
        public LLUsuarios(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _usersRole = new UsuariosRoles();
        }

        internal async Task<List<object[]>> UsuarioLogin(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var appUser1 = _userManager.Users.Where(u => u.Email.Equals(email)).ToList();
                    var appUser2 = _context.TUsuarios.Where(u => u.IdUser.Equals(appUser1[0].Id)).ToList();
                    _userRoles = await _usersRole.getRole(_userManager, _roleManager, appUser1[0].Id);
                    //_userData = new DatosUsuarios
                    //{
                    //    //Id =  appUser1[0].Id,
                    //    Rol = _userRoles[0].Text,
                    //    NombreUsuario = appUser2[0].Nombre + " " + appUser2[0].Apellido,
                    //    Img = appUser2[0].Imagen + ".png"
                    //};
                    code = "0";
                    description = result.Succeeded.ToString();
                }
                else
                {
                    code = "1";
                    description = "Correo o contraseña inválidos";
                }
            }
            catch (Exception ex)
            {

                code = "2";
                description = ex.Message;
            }
            _identityError = new IdentityError
            {
                Code = code,
                Description = description
            };
            object[] data = { _identityError, _userData };
            ListaObjetos.Add(data);
            return ListaObjetos;
        }

        //public string UsuarioDatos(HttpContext httpContext) 
        //{
        //    string rol = null;
        //    var user = httpContext.Session.GetString("Usuario");
        //    if (user != null)
        //    {
        //        DatosUsuarios UsuarioData = JsonConvert.DeserializeObject<DatosUsuarios>(user.ToString());
        //        rol = UsuarioData.Rol;
        //    }
        //    else 
        //    {
        //        rol = "No hay Datos";
        //    }
        //    return rol;
        //}

        public async Task<List<RegistrarMO>> getUsuariosAsync(String valor, int id)
        {
            int cont = 0;
            List<RegistrarMO> usuariosList = new List<RegistrarMO>();
            if (valor == null && id.Equals(0))
            {
                listUser = _context.TUsuarios.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                     listUser = _context.TUsuarios.Where(u => u.NID.StartsWith(valor) || u.Nombre.StartsWith(valor) ||
              u.Apellido.StartsWith(valor)).ToList();
                }
                else
                {
                    listUser = _context.TUsuarios.Where(u => u.ID.Equals(id)).ToList();
                }
            }
            if (!listUser.Count.Equals(0))
            {
                foreach (var item in listUser)
                {
                    var usertel = _userManager.Users.Where(u => u.Id == item.IdUser).ToList();
                    _userRoles = await _usersRole.getRole(_userManager, _roleManager, item.IdUser);
                    usuariosList.Add(new RegistrarMO
                    {
                        ID = item.IdUser,
                        NID = item.NID,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Telefono = usertel[0].PhoneNumber,
                        Rol = _userRoles[cont].Text,
                        Email = item.Imagen
                    });
                    cont++;
                }
            }
            return usuariosList;
        }


    }
}
