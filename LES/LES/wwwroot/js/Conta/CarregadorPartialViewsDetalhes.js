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

function carregarNovoTelefone() {
    carregarPartialView(urls.novoTelefone);
}

function carregarNovoCartao() {
    carregarPartialView(urls.novoCartao);
}

function carregarEditarInfo(){
    carregarPartialView(urls.editarInfoPessoal);
}

function carregarEditarSenha() {
    carregarPartialView(urls.editarSenha);
}

function carregarEditarEndereco(id) {
    var endereco = urls.EditarEndereco + "/" + id;
    carregarPartialView(endereco);
}

function carregarEditarTelefone(id) {
    var endereco = urls.EditarTelefone + "/" + id;
    carregarPartialView(endereco);
}

function carregarEditarCartao(id) {
    var endereco = urls.EditarCartao + "/" + id;
    carregarPartialView(endereco);
}

function carregarRemoverEndereco(id) {
    var endereco = urls.RemoverEndereco + "/" + id;
    carregarPartialView(endereco);
}

function carregarRemoverTelefone(id) {
    var endereco = urls.RemoverTelefone + "/" + id;
    carregarPartialView(endereco);
}

function carregarRemoverCartao(id) {
    var endereco = urls.RemoverCartao + "/" + id;
    carregarPartialView(endereco);
}

function carregarRealizarTroca(id) {
    var endereco = urls.RealizarTroca + "/" + id;
    carregarPartialView(endereco);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

$("#btnEditarInfo").on("click", function (e) {
    carregarEditarInfo();
});

$("#btnEditarSenha").on("click", function (e) {
    carregarEditarSenha();
});

$("#addNovoEnderecoLink").on("click", function (e) {
    carregarNovoEndereco();
});

$("#addNovoTelefoneLink").on("click", function (e) {
    carregarNovoTelefone();
});

$("#addNovoCartaoLink").on("click", function (e) {
    carregarNovoCartao();
});

$(".botaoEndereco").on("click", function (e) {
    var id = $(this).val(); 
    carregarEditarEndereco(id);
});

$(".botaoTelefone").on("click", function (e) {
    var id = $(this).val();
    carregarEditarTelefone(id);
});

$(".botaoCartao").on("click", function (e) {
    var id = $(this).val();
    carregarEditarCartao(id);
});

$(".botaoRemoverEndereco").on("click", function (e) {
    var id = $(this).val();
    carregarRemoverEndereco(id);
});

$(".botaoRemoverTelefone").on("click", function (e) {
    var id = $(this).val();
    carregarRemoverTelefone(id);
});

$(".botaoRemoverCartao").on("click", function (e) {
    var id = $(this).val();
    carregarRemoverCartao(id);
});

$(".btnTroca").on("click", function (e) {
    var id = $(this).val();
    carregarRealizarTroca(id);
});



