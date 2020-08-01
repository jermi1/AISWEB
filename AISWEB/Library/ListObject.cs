using AISWEB.Areas.Usuarios.Models;
using AISWEB.Data;
using AISWEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISWEB.Library
{
    public class ListObject
    {
        public String description, code;

        public UsuariosRoles _usersRole; //metodos para obtener roles
        public DatosUsuarios _userData;
        public LLUsuarios _usuarios;
        public SubirImagen _image;
        public IdentityError _identityError;
        public ApplicationDbContext _context;
        // para obtener la direccion url de la app y asi almacenar las imagenes en carpeta
        public IHostingEnvironment _environment;

        public List<SelectListItem> _userRoles; //para guardar roles de un usuario en una lista para ponerlas en combo
        public List<SelectListItem> _Roles;
        public List<TUsuarios> listUser;


        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;

        public List<object[]> ListaObjetos = new List<object[]>();
    }
}
