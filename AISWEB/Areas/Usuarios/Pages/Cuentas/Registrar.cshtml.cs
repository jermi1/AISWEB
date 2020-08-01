using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AISWEB.Areas.Usuarios.Controllers;
using AISWEB.Areas.Usuarios.Models;
using AISWEB.Data;
using AISWEB.Library;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AISWEB.Areas.Usuarios.Pages.Cuentas
{
    public class RegistrarModel : PageModel
    {
        private ListObject listObject = new ListObject();
        private static String idGet = null;
        private static List<IdentityUser> Lusuarios1;
        private static List<TUsuarios> Lusuarios2;

        public RegistrarModel(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager ,IHostingEnvironment environment, ApplicationDbContext context) 
        {
            listObject._roleManager = roleManager;
            listObject._environment = environment;
            listObject._userManager = userManager;
            listObject._context = context;
            listObject._usuarios = new LLUsuarios();
            listObject._usersRole = new UsuariosRoles();
            listObject._image = new SubirImagen();
            listObject._userRoles = new List<SelectListItem>();
        }

        // EL metodo Onget se ejecuta na bien ingreso
        public async Task OnGet(String id)
        {
            if (id != null)
            {
                idGet = id;
                await setEditarAsync(id);
            }
            else
            {
                Input = new InputModel
                {
                    listaRoles = listObject._usersRole.getRoles(listObject._roleManager)
                };
            }
        }
        [BindProperty]
        public InputModel Input { get; set; } //para obetener las propiedades de la clase inputmodel en la pagina razor
        public class InputModel : RegistrarMO
        {

         public IFormFile ImagenAvatarU { get; set; }
         [TempData]
         public string ErrorMessage { get; set; }
         public List<SelectListItem> listaRoles { get; set; }
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (idGet == null)
            {
                //bool valor = 
                await guardar();
                return Page();
            }
            else {
                idGet = null;
                bool valor = await actualizarAsync();
                if (valor)          
                {
                    return RedirectToAction(nameof(UsuariosController.Usuarios), "Usuarios"); } else{return Page();}
            }
            //if (valor) 
            //{return Page();}//else 
            //{ return Page(); }
        }
        private async Task<bool> guardar() 
        {
            var valor = false;
            try
            {
                if (ModelState.IsValid)
                {
                    listObject._userRoles.Add(new SelectListItem
                    {
                        Text = Input.Rol
                    });
                    var userList = listObject._userManager.Users.Where(u => u.Email == Input.Email).ToList();
                    if (userList.Count == 0)
                    {
                        var imageName = Input.Email + ".png";
                        var user = new IdentityUser
                        {
                            UserName = Input.Email,
                            Email = Input.Email,
                            PhoneNumber = Input.Telefono
                        };
                        var result = await listObject._userManager.CreateAsync(user, Input.Password);
                        if (result.Succeeded)
                        {
                            await listObject._userManager.AddToRoleAsync(user, Input.Rol);
                            var listUser = listObject._userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList();
                            var Usuario = new TUsuarios
                            {
                                Nombre = Input.Nombre,
                                Apellido = Input.Apellido,
                                NID = Input.NID,
                                Imagen = Input.Email,
                                IdUser = listUser[0].Id
                            };
                            await listObject._context.AddAsync(Usuario);
                            listObject._context.SaveChanges();
                            await listObject._image.copiarImagenAsync(Input.ImagenAvatarU, imageName, listObject._environment, "Usuarios", null);
                            Input = new InputModel
                            {
                                ErrorMessage = "Usuario ingresado con Exito!",
                                listaRoles = listObject._userRoles
                            };
                            valor = true;
                        }
                        else
                        {
                            //result.Errors  contiene la coleccion de datos de la clase IdentityError
                            foreach (var item in result.Errors)
                            {
                                Input = new InputModel
                                {
                                    ErrorMessage = item.Description,
                                    listaRoles = listObject._userRoles
                                };
                            }
                            valor = false;
                        }
                    }
                    else
                    {
                        Input = new InputModel
                        {
                            ErrorMessage = "El " + Input.Email + " ya esta registrado",
                            listaRoles = listObject._userRoles
                        };
                        valor = false;
                    }

                }
                else 
                {
                    Input = new InputModel
                    {
                        ErrorMessage = "Seleccione un rol",
                        listaRoles = listObject._usersRole.getRoles(listObject._roleManager)
                    };
                }
            }
            catch (Exception e)
            {
                Input = new InputModel
                {
                    ErrorMessage = e.Message,
                    listaRoles = listObject._userRoles
                };
                 valor = false;

            }
            return valor;
        }
        //Para cargar la informacion del usuario en la vista editar
        private async Task setEditarAsync(string Email)
        {
            Lusuarios1 = listObject._userManager.Users.Where(u => u.Email.Equals(Email)).ToList();
            Lusuarios2 = listObject._context.TUsuarios.Where(u => u.IdUser.Equals(Lusuarios1[0].Id)).ToList();
            var userRoles = await listObject._usersRole.getRole(listObject._userManager, listObject._roleManager, Lusuarios1[0].Id);

            Input = new InputModel
            {
                Nombre = Lusuarios2[0].Nombre,
                Apellido = Lusuarios2[0].Apellido,
                NID = Lusuarios2[0].NID,
                Telefono = Lusuarios1[0].PhoneNumber,
                Email = Lusuarios1[0].Email,
                Password = "*********",
                listaRoles = getRolesEditar(userRoles[0].Text)
            };
        }
        private async Task<bool> actualizarAsync()
        {
            var valor = false;
            try {
                if (ModelState.IsValid)
                {
                    var identityUser = new IdentityUser
                    {
                        Id = Lusuarios1[0].Id,
                        UserName = Input.Email,
                        Email = Input.Email,
                        PhoneNumber = Input.Telefono,
                        EmailConfirmed = Lusuarios1[0].EmailConfirmed,
                        LockoutEnabled = Lusuarios1[0].LockoutEnabled,
                        LockoutEnd = Lusuarios1[0].LockoutEnd,
                        NormalizedEmail = Lusuarios1[0].NormalizedEmail,
                        NormalizedUserName = Lusuarios1[0].NormalizedUserName,
                        PasswordHash = Lusuarios1[0].PasswordHash,
                        PhoneNumberConfirmed = Lusuarios1[0].PhoneNumberConfirmed,
                        SecurityStamp = Lusuarios1[0].SecurityStamp,
                        TwoFactorEnabled = Lusuarios1[0].TwoFactorEnabled,
                        AccessFailedCount = Lusuarios1[0].AccessFailedCount,
                        ConcurrencyStamp = Lusuarios1[0].ConcurrencyStamp
                    };
                    listObject._context.Update(identityUser);
                    await listObject._context.SaveChangesAsync();
                    var usuarios = new TUsuarios
                    {
                        ID = Lusuarios2[0].ID,
                        Nombre = Input.Nombre,
                        Apellido = Input.Apellido,
                        NID = Input.NID,
                        Imagen = Input.Email,
                        IdUser = Lusuarios1[0].Id,
                    };
                    listObject._context.Update(usuarios);
                    await listObject._context.SaveChangesAsync();
                    var imageName = Input.Email + ".png";
                    await listObject._image.copiarImagenAsync(Input.ImagenAvatarU, imageName, listObject._environment, "Usuarios", idGet);
                    Input = new InputModel
                    {
                        ErrorMessage = "Usuario Editado con Exito!",
                        listaRoles = listObject._userRoles
                    };
                    valor = true;
                }
                else 
                {
                    Input = new InputModel
                    {
                        ErrorMessage = "ErroR al actualizar usuario, datos no validos",
                        listaRoles = listObject._usersRole.getRoles(listObject._roleManager)
                    };
                    valor = false;
                }
            }
            catch (Exception ex) 
            {
                Input = new InputModel
                {
                    ErrorMessage = ex.Message,
                    listaRoles = getRolesEditar(Input.Rol)
                };
                valor = false;
            }
            return valor;

        }
        private List<SelectListItem> getRolesEditar(String role)
        {// Al editar un usuario que se cargue el rol del usuario seleccionado primero en el combo box de la vista editarUsuario
            listObject._userRoles.Add(new SelectListItem
            {
                Text = role
            });
            var roles = listObject._usersRole.getRoles(listObject._roleManager);
            roles.ForEach(item => {
                if (item.Text != role)
                {
                    listObject._userRoles.Add(new SelectListItem
                    {
                        Text = item.Text
                    });
                }
            });
            return listObject._userRoles;
        }

    }
}
