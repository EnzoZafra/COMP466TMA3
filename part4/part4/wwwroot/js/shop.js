$(document).ready(function(){
    $('.modal').modal();
});

function addCart(pid) {
    var cookie = readCookie("cart")
    if (cookie != null) {
        cookie = "cart=" + cookie + pid + "/"
    }
    else {
        cookie = "cart=" + pid + "/"
    }
    document.cookie = cookie;

    $('#cartmodal').modal('open'); 
}