
var getParameterByName = (name) => {
    //El método replace () busca una cadena para un valor específico, o una expresión regular , y devuelve una nueva cadena donde se reemplazan los valores especificados.
    console.log("id:"+name);

    //name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    // console.log("name: "+name);
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    //console.log("regex: " + name);
    //console.log("results: " + results);
    //var dd = decodeURIComponent(results[1].replace(/\+/g, " "));
    //console.log("dd: " + dd);

    // La función decodeURIComponent() decodifica un componente URI.
    return results === null ? null : decodeURIComponent(results[1].replace(/\+/g, " "));


}
//var printThisDiv = (id) => {
//    var printContents = document.getElementById(id).innerHTML;
//    var originalContents = document.body.innerHTML;
//    document.body.innerHTML = printContents;
//    window.print();
//    document.body.innerHTML = originalContents;
//}