function clearCart() 
{
   del_cookie("cart")
   location.reload();
}

function del_cookie(name) 
{
    document.cookie = name+'=; Max-Age=-99999999;';  
};