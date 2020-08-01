using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AISWEB.Library
{
    public class SubirImagen
    {
        public async Task copiarImagenAsync(IFormFile AvatarImage, string fileName, IHostingEnvironment environment, string carpeta, String imagen)
        {
            //el usuario NO selecciono una imagen --> metodo para darle una imagen por defecto xd
            if (null == AvatarImage)
            {
                String archivoOrigen;
                var destFileName = environment.ContentRootPath + "/wwwroot/img/fotosUpload/" + carpeta + "/" + fileName;
                if (imagen == null)
                {//no es necesario obtener el email del usuario por que solo lo vamos a guardar xd
                    archivoOrigen = environment.ContentRootPath + "/wwwroot/img/fotosUpload/" + carpeta + "/default.png";
                    File.Copy(archivoOrigen, destFileName, true); // para poner la imagen por dafult con el nombre del email.png
                }
                // para actualizar imagen existente
                else 
                {
                    archivoOrigen = environment.ContentRootPath + "/wwwroot/img/fotosUpload/" + carpeta + "/" + imagen + ".png";
                    //se va actualizar la imagen con el nuevo correo electronico del usuario
                    if (fileName != imagen + ".png")
                    {
                        File.Copy(archivoOrigen, destFileName, true); //nuevo correo del usuario actualizado 
                        File.Delete(archivoOrigen); // borramos lo que se tiene guardado en File
                    }

                }
            }
            //si es que el usuario selecciono una imagen
            else
            {
                var filePath = Path.Combine(environment.ContentRootPath, "wwwroot/img/fotosUpload/" + carpeta, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AvatarImage.CopyToAsync(stream);
                }
            }
        }
    }
}
