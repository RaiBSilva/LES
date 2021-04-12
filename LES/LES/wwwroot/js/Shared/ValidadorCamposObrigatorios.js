function shake(thing) {
    var interval = 100;
    var distance = 10;
    var times = 6;

    for (var i = 0; i < (times + 1); i++) {
        $(thing).animate({
            left:
                (i % 2 == 0 ? distance : distance * -1)
        }, interval);
    }
    $(thing).animate({
        left: 0,
        top: 0
    }, interval);
};

function makeRed(thing) {
    $(thing).css('border-color', 'red')
};

function validaCampos(listaRequired) {

    var validados = true;

    $(listaRequired).each(function (i) {
        if ($(this).val == "") {
            validados = false;
            shake(this);
            makeRed(this);
        }
    });

    return validados;
};

function validaInput(e) {

    inputAlterado = e.target;
    if ($(inputAlterado).val = "") {
        shake(inputAlterado);
        makeRed(inputAlterado);
    }
};

$(".required").on("input", function (e) {
    validaInput(e);
});

$(".requiredForm").one("submit", function (e) {

    e.preventDefault();
    var listaRequired = $(".required");

    if (validaCampos(listaRequired)) {
        $(this).submit();
    }
});