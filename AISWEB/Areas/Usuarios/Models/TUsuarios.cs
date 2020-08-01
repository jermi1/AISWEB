﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISWEB.Areas.Usuarios.Models
{
    public class TUsuarios
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NID { get; set; }
        public string Imagen { get; set; }
        public string IdUser { get; set; } //para relacionar esta tabla con la tabla  por defecto user del identity
    }
}
