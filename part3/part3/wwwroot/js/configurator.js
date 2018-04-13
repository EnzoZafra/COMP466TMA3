prices = {}
selectedPrice = {}
selectedItem = {}
cart = ""

function buynow() {
    cart = ""
    for (var key in selectedItem) {
        cart += key + "~" + selectedItem[key] + '/'
    }
    document.cookie = 'cart=' + cart
    return true;
}

$("#processor").on('change', function() {
    selectedItem["cpu"] = $(this).val();
    selectedPrice["cpu"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["cpu"]
    document.getElementById("cpuprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#motherboard").on('change', function() {
    selectedItem["mb"] = $(this).val();
    selectedPrice["mb"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["mb"]
    document.getElementById("mbprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#ram").on('change', function() {
    selectedItem["ram"] = $(this).val();
    selectedPrice["ram"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["ram"]
    document.getElementById("ramprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#harddrive").on('change', function() {
    selectedItem["hdd"] = $(this).val();
    selectedPrice["hdd"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["hdd"]
    document.getElementById("hddprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#videocard").on('change', function() {
    selectedItem["gpu"] = $(this).val();
    selectedPrice["gpu"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["gpu"]
    document.getElementById("gpuprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#powersupply").on('change', function() {
    selectedItem["psu"] = $(this).val();
    selectedPrice["psu"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["psu"]
    document.getElementById("psuprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#soundcard").on('change', function() {
    selectedItem["sc"] = $(this).val();
    selectedPrice["sc"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["sc"]
    document.getElementById("scprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

$("#os").on('change', function() {
    selectedItem["os"] = $(this).val();
    selectedPrice["os"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["os"]
    document.getElementById("osprice").innerHTML = "$" + price.toFixed(2);
    updateTotal()
});

function updateTotal() {
    var total = selectedPrice["cpu"] + selectedPrice["mb"]
                + selectedPrice["ram"] + selectedPrice["hdd"]
                + selectedPrice["gpu"] + selectedPrice["psu"]
                + selectedPrice["sc"] + selectedPrice["os"]
    document.getElementById("totalprice").innerHTML = "$" + total.toFixed(2);
}

function storePrices() {
    //TODO: hardcoded db in part 4
    var counter = 0;
    for (var i = 0; i < 5; i++) 
    {
        prices[++counter] = 499.99
        prices[++counter] = 374.99
        prices[++counter] = 89.99
        prices[++counter] = 224.99
        prices[++counter] = 129.99
        prices[++counter] = 49.99
        prices[++counter] = 89.99
        prices[++counter] = 119.99
    }
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for(var i=0;i < ca.length;i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
    }
    return null;
}

function initStore() {
    storePrices()
    setSelectedItem()
    $('#processor').trigger("change");
    $('#motherboard').trigger("change");
    $('#videocard').trigger("change");
    $('#powersupply').trigger("change");
    $('#harddrive').trigger("change");
    $('#os').trigger("change");
    $('#ram').trigger("change");
    $('#soundcard').trigger("change");
}

function setSelectedItem() {
    $('#processor').val(readCookie("pickedcpu"));
    $('#motherboard').val(readCookie("pickedmb"));
    $('#videocard').val(readCookie("pickedgpu"));
    $('#powersupply').val(readCookie("pickedpsu"));
    $('#harddrive').val(readCookie("pickedhdd"));
    $('#os').val(readCookie("pickedos"));
    $('#ram').val(readCookie("pickedram"));
    $('#soundcard').val(readCookie("pickedsc"));

    // re-initialize material-select
    $('#myselect').material_select();
}

initStore()