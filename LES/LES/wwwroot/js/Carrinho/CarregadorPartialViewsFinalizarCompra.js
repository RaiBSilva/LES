function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-lg";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}


function carregarNovoEndereco() {
    carregarPartialView(urls.novoEndereco);
}

function carregarNovoCartao() {
    carregarPartialView(urls.novoCartao);
}

function carregarCalcularFrete() {
    carregarPartialView(urls.calcularFrete);
}

function carregarUsarCupom(){
    carregarPartialView(urls.usarCupom);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

$(".btnEndereco").on("click", function (e) {
    carregarNovoEndereco();
});

$(".btnCartao").on("click", function (e) {
    carregarNovoCartao();
});

$(".btnFrete").on("click", function (e) {
    carregarCalcularFrete();
});

$(".btnUsarCupom").on("click", function (e) {
    carregarUsarCupom();
});

