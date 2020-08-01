$(document).ready(function () {

    if (localStorage.getItem('liactivo'))
    { 
    let liId = JSON.parse(localStorage.getItem('liactivo'));
    

    if (liId.cp)
    {
        var liAct = $(`#${liId.li}`);
        var li2 = $(`#${liId.liu}`);               

        liAct.addClass("active active-sm");
        $('ul:first', liAct).slideDown(function () {
        });
        li2.addClass('current-page');
            
    
        localStorage.clear();

    }
    }   

});

