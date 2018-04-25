selectedPrice = {}
selectedItem = {}

function buynow() {
    var cart = ""
    for (var key in selectedItem) {
        if(selectedItem[key] != null) {
            cart += selectedItem[key] + '/'
        }
    }
    console.log(cart)
    var cookie = readCookie("cart")
    if (cookie != null) {
        cookie = "cart=" + cookie + cart
    }
    else {
        cookie = "cart=" + cart
    }
    document.cookie = cookie;
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
    //$.getJSON("/black-pearl/crew", function(crewResponse) {
    //    pirates = crewResponse.pirates;
    //});
}

function oldstorePrices() {
// TODO: need to query MYSQL in javascript.. 
// Try calling a PHP file
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