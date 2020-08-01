
class Principal {
    constructor() {
        var URLact = window.location.pathname;
    }

   userLink(URLact) {
    console.log(URLact);

    if (URLact == "/Usuarios/Cuentas/Registrar" || URLact == "/Usuarios/Cuentas/Registrar/")
    {

        var id = getParameterByName('id');
        console.log(id);
        if (id != null) {
            document.getElementById("Input_Rol").selectedIndex = 1;
            document.getElementById("imageRgistrar").innerHTML = ['<img class="responsive-img " src="', URL + "img/fotosUpload/Usuarios/" + id + ".png", '" title="', escape(id), '"/>'].join('');
            $("#divPassword").hide();
        }
    }
    
    }
}