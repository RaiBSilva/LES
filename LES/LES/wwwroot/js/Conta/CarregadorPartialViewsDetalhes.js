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

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
})

document.getElementById("addNovoEnderecoLink").addEventListener("click", function (e) {
    carregarNovoEndereco();
});

document.getElementById("addNovoTelefoneLink").addEventListener("click", function (e) {
    carregarNovoTelefone();
});

document.getElementById("addNovoCartaoLink").addEventListener("click", function (e) {
    carregarNovoCartao();
});

$("#btnEditarInfo").on("click", function (e) {
    carregarEditarInfo();
});

$("#btnEditarSenha").on("click", function (e) {
    carregarEditarSenha();
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

