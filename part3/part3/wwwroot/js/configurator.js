prices = {}
selectedPrice = {}
initStore()
updateTotal()
storePrices("test")

$("#processor").on('change', function() {
    selectedPrice["cpu"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["cpu"]
    if (price == 0) { 
        document.getElementById("cpuprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("cpuprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#motherboard").on('change', function() {
    selectedPrice["mb"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["mb"]
    if (price == 0) { 
        document.getElementById("mbprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("mbprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#ram").on('change', function() {
    selectedPrice["ram"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["ram"]
    if (price == 0) { 
        document.getElementById("ramprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("ramprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#harddrive").on('change', function() {
    selectedPrice["hdd"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["hdd"]
    if (price == 0) { 
        document.getElementById("hddprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("hddprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#videocard").on('change', function() {
    selectedPrice["gpu"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["gpu"]
    if (price == 0) { 
        document.getElementById("gpuprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("gpuprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#powersupply").on('change', function() {
    selectedPrice["psu"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["psu"]
    if (price == 0) { 
        document.getElementById("psuprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("psuprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#soundcard").on('change', function() {
    selectedPrice["sc"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["sc"]
    if (price == 0) { 
        document.getElementById("scprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("scprice").innerHTML = "$" + price;
    }
    updateTotal()
});

$("#os").on('change', function() {
    selectedPrice["os"] = parseFloat(prices[$(this).val()] || 0);
    var price = selectedPrice["os"]
    if (price == 0) { 
        document.getElementById("osprice").innerHTML = "$" + price + ".00";
    }
    else {
        document.getElementById("osprice").innerHTML = "$" + price;
    }
    updateTotal()
});

function updateTotal() {
    var total = selectedPrice["cpu"] + selectedPrice["mb"]
                + selectedPrice["ram"] + selectedPrice["hdd"]
                + selectedPrice["gpu"] + selectedPrice["psu"]
                + selectedPrice["sc"] + selectedPrice["os"]
                
    if (total == 0) { 
        document.getElementById("totalprice").innerHTML = "$" + total + ".00";
    }
    else {
        document.getElementById("totalprice").innerHTML = "$" + total;
    }
}

function storePrices(obj) {
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

function initStore() {
    selectedPrice["cpu"] = 0
    selectedPrice["mb"] = 0
    selectedPrice["ram"] = 0
    selectedPrice["gpu"] = 0
    selectedPrice["hdd"] = 0
    selectedPrice["psu"] = 0
    selectedPrice["sc"] = 0
    selectedPrice["os"] = 0
}