function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-lg";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

//Livros

function carregarAdicionarLivro() {
    var endereco = urls.AdicionarLivro;
    carregarPartialView(endereco);
}

function carregarEntradaEstoqueLivro(id) {
    var endereco = urls.EntradaEstoqueLivro + "/" + id;
    carregarPartialView(endereco);
}

function carregarVisualizarLivro(id) {
    var endereco = urls.VisualizarLivro + "/" + id;
    carregarPartialView(endereco);
}

function carregarEditarLivro(id) {
    var endereco = urls.EditarLivro + "/" + id;
    carregarPartialView(endereco);
}

function carregarInativarLivro(id) {
    var endereco = urls.InativarLivro + "/" + id;
    carregarPartialView(endereco);
}

//Categorias

function carregarAdicionarCategoria() {
    var endereco = urls.AdicionarCategoria;
    carregarPartialView(endereco);
}

function carregarEditarCategoria(id) {
    var endereco = urls.EditarCategoria + "/" + id;
    carregarPartialView(endereco);
}

function carregarInativarCategoria(id) {
    var endereco = urls.InativarCategoria + "/" + id;
    carregarPartialView(endereco);
}

//GrupoPreço

function carregarAdicionarGrupoPreco() {
    var endereco = urls.AdicionarGrupoPreco;
    carregarPartialView(endereco);
}

function carregarEditarGrupoPreco(id) {
    var endereco = urls.EditarGrupoPreco + "/" + id;
    carregarPartialView(endereco);
}

function carregarInativarGrupoPreco(id) {
    var endereco = urls.InativarGrupoPreco + "/" + id;
    carregarPartialView(endereco);
}

//Livros

$(".btnAddLivro").on("click", function (e) {
    carregarAdicionarLivro();
});

$(".btnEntradaEstoqueLivro").on("click", function (e) {
    var id = $(this).val();
    carregarEntradaEstoqueLivro(id);
});

$(".btnVisualizarLivro").on("click", function (e) {
    var id = $(this).val();
    carregarVisualizarLivro(id);
});

$(".btnEditarLivro").on("click", function (e) {
    var id = $(this).val();
    carregarEditarLivro(id);
});

$(".btnInativarLivro").on("click", function (e) {
    var id = $(this).val();
    carregarInativarLivro(id);
});

//Categorias

$(".btnAddCategoria").on("click", function (e) {
    carregarAdicionarCategoria();
});

$(".btnEditarCategoria").on("click", function (e) {
    var id = $(this).val();
    carregarEditarCategoria(id);
});

$(".btnInativarCategoria").on("click", function (e) {
    var id = $(this).val();
    carregarInativarCategoria(id);
});

//GrupoPreço

$(".btnAddGrupoPreco").on("click", function (e) {
    carregarAdicionarGrupoPreco();
});

$(".btnEditarGrupoPreco").on("click", function (e) {
    var id = $(this).val();
    carregarEditarGrupoPreco(id);
});

$(".btnInativarGrupoPreco").on("click", function (e) {
    var id = $(this).val();
    carregarInativarGrupoPreco(id);
});