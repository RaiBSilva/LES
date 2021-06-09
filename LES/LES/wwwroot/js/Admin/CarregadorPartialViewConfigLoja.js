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
    var endereco = urls.EntradaEstoqueLivro + "?cod=" + id;
    carregarPartialView(endereco);
}

function carregarVisualizarLivro(id) {
    var endereco = urls.VisualizarLivro + "?cod=" + id;
    carregarPartialView(endereco);
}

function carregarEditarLivro(id) {
    var endereco = urls.EditarLivro + "?cod=" + id;
    carregarPartialView(endereco);
}

function carregarInativarLivro(id) {
    var endereco = urls.InativarLivro + "?cod=" + id;
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
    var endereco = urls.EditarGrupoPreco + "?cod=" + id;
    carregarPartialView(endereco);
}

function carregarInativarGrupoPreco(id) {
    var endereco = urls.InativarGrupoPreco + "?cod=" + id;
    carregarPartialView(endereco);
}

//CodigoPromocional

function carregarAdicionarCodigo() {
    var endereco = urls.AdicionarCodigo;
    carregarPartialView(endereco);
}

function carregarEditarCodigo(id) {
    var endereco = urls.EditarCodigo + "/" + id;
    carregarPartialView(endereco);
}

function carregarInativarCodigo(id) {
    var endereco = urls.InativarCodigo + "/" + id;
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

//GrupoPreço

$(".btnAddCodigo").on("click", function (e) {
    carregarAdicionarCodigo();
});

$(".btnEditarCodigo").on("click", function (e) {
    var id = $(this).val();
    carregarEditarCodigo(id);
});

$(".btnInativarCodigo").on("click", function (e) {
    var id = $(this).val();
    carregarInativarCodigo(id);
});

function criaTriggers() {
    $('.btnAddLivro').unbind('click');
    $('.btnEntradaEstoqueLivro').unbind('click');
    $('.btnVisualizarLivro').unbind('click');
    $('.btnEditarLivro').unbind('click');
    $('.btnInativarLivro').unbind('click');
    $('.btnAddCategoria').unbind('click');
    $('.btnEditarCategoria').unbind('click');
    $('.btnInativarCategoria').unbind('click');
    $('.btnAddGrupoPreco').unbind('click');
    $('.btnEditarGrupoPreco').unbind('click');
    $('.btnInativarGrupoPreco').unbind('click');
    $('.btnAddCodigo').unbind('click');
    $('.btnEditarCodigo').unbind('click');
    $('.btnInativarCodigo').unbind('click');

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

    //GrupoPreço

    $(".btnAddCodigo").on("click", function (e) {
        carregarAdicionarCodigo();
    });

    $(".btnEditarCodigo").on("click", function (e) {
        var id = $(this).val();
        carregarEditarCodigo(id);
    });

    $(".btnInativarCodigo").on("click", function (e) {
        var id = $(this).val();
        carregarInativarCodigo(id);
    });
}

