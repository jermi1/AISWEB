$(document).ready(function () {
    var cambioPagina = false;

    $('.child_menu').find('a').click(function () {
        var $li = $(this).parent().parent().parent();
        var $liiu = $(this).parent();

        cambioPagina = true;
        let obj =
        {
            li: $($li).attr('id'),
            liu: $($liiu).attr('id'), 
            cp: cambioPagina
        }

        if ($li.hasClass("active")) {
            localStorage.setItem('liactivo', JSON.stringify(obj));
        }

        window.location.href = $(this).attr("href");

    });
});

/*CODIGO DE USUARIOS*/
var usuarios = new Usuario();
var imageUser = (evt) => {
    usuarios.archivo(evt, "imageRgistrar");
}

$().ready(() => {
    var URLactual = window.location.pathname;
    if (URLactual == "/Usuarios/Cuentas/Registrar" || URLactual == "/Usuarios/Cuentas/Registrar/") {
        document.getElementById('files').addEventListener('change', imageUser, false);
        var id = getParameterByName('id');
        if (id != null) {
            document.getElementById("Input_Rol").selectedIndex = 1;
            document.getElementById("imageRgistrar").innerHTML = ['<img class="responsive-img " src="', url + "img/fotosUpload/Usuarios/" + id + ".png", '" title="', escape(id), '"/>'].join('');
            //document.getElementById("divPassword").disabled = true;
            $("#divPassword").hide();
        }
    }
});