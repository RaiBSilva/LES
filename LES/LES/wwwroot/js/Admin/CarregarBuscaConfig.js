function atualizarLista(pag, tabela) {
    if (pag === undefined) pag = 1;

    alert(tabela);

    var divTabela = $("#" + tabela);

    var Pesquisar;
    var filtros;

    if (tabela = "Livros") {
        Pesquisar = urls.BuscarLivros;
        filtros = JSON.stringify({
            Id: $("#filtroLivId").val(),
            TituloAutor: $("#filtroLivTituloAutor").val(),
            ValorMin: $("#filtroLivValorMin").val(),
            ValorMax: $("#filtroLivValorMax").val(),
            Categorias: $("#filtroLivCategorias").val(),
            IncluiInativos: $("#filtroLivInativos").is(":checked"),
            PagAtual: pag
        });
    }
    if (tabela = "Categorias") {
        Pesquisar = urls.BuscarCategorias;
        filtros = JSON.stringify({
            Id: $("#filtroCatId").val(),
            Nome: $("#filtroCatNome").val(),
            IncluiInativados: $("#filtroCatInativados").is(":checked"),
            PagAtual: pag
        });
    }
    if (tabela = "Grupos") {
        Pesquisar = urls.BuscarGrupos
        filtros = JSON.stringify({
            Id: $("#filtroGrpId").val(),
            Nome: $("#filtroGrpNome").val(),
            IncluiInativo: $("#filtroGrpInativo").is(":checked"),
            MargemMax: $("#filtroGrpMargemMax").val(),
            MargemMin: $("#filtroGrpMargemMin").val(),
            PagAtual: pag
        });

    };

    divTabela.load(Pesquisar,
        {
            json: filtros
        }, function () {
            $('.btnBuscarLiv').unbind('click');
            $('.btnPageLiv').unbind('click');
            $('.btnBuscarCat').unbind('click');
            $('.btnPageCat').unbind('click');
            $('.btnBuscarGrp').unbind('click');
            $('.btnPageGrp').unbind('click');

            $(".btnBuscarLiv").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1, "Livros");
            });

            $(".btnPageLiv").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag, "Livros");
            });

            $(".btnBuscarCat").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1, "Categorias");
            });

            $(".btnPageCat").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag, "Categorias");
            });

            $(".btnBuscarGrp").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1, "Grupos");
            });

            $(".btnPageGrp").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag, "Grupos");
            });
        });
};

$(".btnBuscarLiv").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1, "Livros");
});

$(".btnPageLiv").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag, "Livros");
});

$(".btnBuscarCat").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1, "Categorias");
});

$(".btnPageCat").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag, "Categorias");
});

$(".btnBuscarGrp").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1, "Grupos");
});

$(".btnPageGrp").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag, "Grupos");
});