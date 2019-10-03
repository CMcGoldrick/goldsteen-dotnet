function copyBtcAddress() {
    var copyText = document.getElementById("btc-address");
    copyText.select();
    document.execCommand("copy");
}



//-- calculator --
function calC(c) {
    form.panel.value = form.panel.value + c;
}

function CE() {
    form.panel.value = "";
}

function copyCalcVal() {
    var copyText = document.getElementById("panel");
    copyText.select();
    document.execCommand("copy");
}



