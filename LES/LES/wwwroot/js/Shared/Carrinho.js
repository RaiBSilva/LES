// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function carregarCarrinho(msg, classe) {
    if (msg === undefined) msg = "";
    if (classe === undefined) msg = "";

    var divDropdown = document.getElementById("dropdown");

    $(divDropdown).load(carrinhoUrl, function () {

        $(".mais-carrinho").on("click", function (e) {
            e.preventDefault();
            var codBar = $(this).val();
            opCarrinho(codBar, carrinhoMais);
        });

        $(".menos-carrinho").on("click", function (e) {
            e.preventDefault();
            var codBar = $(this).val();
            opCarrinho(codBar, carrinhoMenos);
        });

        $(".remover-carrinho").on("click", function (e) {
            e.preventDefault();
            var codBar = $(this).val();
            opCarrinho(codBar, carrinhoRemover);
        });

    });
    if (msg != "") appendAlert(msg, classe);
}

function appendAlert(msg, classe) {
    var divAlert = $("#alertCarrinho");

    divAlert[0].innerHTML =
        '<div class="alert'+ classe +'alert-dismissible fade show" role="alert">' +
            '<strong>ERRO</strong>' +
                msg +
            '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span>' +
            '</button>' +
        '</div>';
};

function desativarBtns() {
    $(".mais-carrinho").prop("disabled", true);
    $(".menos-carrinho").prop("disabled", true);
    $(".remover-carrinho").prop("disabled", true);
    $(".btn-carrinho-comprar").prop("disabled", true);
    $(".addToCarrinho").prop("disabled", true);
};

function reativarBtns() {
    $(".mais-carrinho").prop("disabled", false);
    $(".menos-carrinho").prop("disabled", false);
    $(".remover-carrinho").prop("disabled", false);
    $(".btn-carrinho-comprar").prop("disabled", false);
    $(".addToCarrinho").prop("disabled", false);
};

function opCarrinho(codBar, endereco) {
    $.ajax({
        url: endereco,
        method: 'POST',
        dataType: 'json',
        data: {codBar: codBar},
        beforeSend: desativarBtns(),
        success: function (dados) {
            if (dados.valor == true) carregarCarrinho("Feito!", "alert-success");
            else carregarCarrinho(dados.msg, "alert-danger");
        },
        complete: reativarBtns()
    })
};

$(".carrinho-update").on("click", function (e) {
    e.preventDefault();
    carregarCarrinho();
});

carregarCarrinho();