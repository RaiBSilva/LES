function makeRed(thing) {
    $(thing).css("border", "2px solid red")
};

function makeGreen(thing) {
    $(thing).css("border", "2px solid green")
};

function checaVazio(input) {

    if (!$(input).val()) {
        makeRed(input);
        return true;
    }
    else {
        $(input).removeAttr("style");
        return false;
    }
}

function validaCampos(listaRequired) {

    var validados = true;

    $(listaRequired).each(function (i) {
        if (checaVazio($(this))) {
            validados = false;
        }
    });

    return validados;
};

function validaInput(e) {
    inputAlterado = e.target;
    checaVazio(inputAlterado);
};

$(document).ready(function() {
    $(".required").on("input", function (e) {
        validaInput(e);
    });
});

