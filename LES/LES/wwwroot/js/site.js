// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function carregarCarrinho(endereco) {

    var divDropdown = document.getElementById("dropdown");

    $(divDropdown).load(endereco);
}

$(".carrinho-update").on("click", function (e) {
    carregarCarrinho(carrinhoUrl);
});

carregarCarrinho(carrinhoUrl);