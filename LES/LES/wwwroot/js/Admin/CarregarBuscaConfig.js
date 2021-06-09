function atualizarLista(pag, tabela) {
    if (pag === undefined) pag = 1;

    var divTabela = $("#" + tabela);

    var Pesquisar;
    var filtros;

    if (tabela == "Livros") {
        Pesquisar = urls.BuscarLivros;
        filtros = JSON.stringify({
            Id: $("#filtroLivId").val(),
            TituloAutor: $("#filtroLivTituloAutor").val(),
            ValorMin: $("#filtroLivValorMin").val(),
            ValorMax: $("#filtroLivValorMax").val(),
            Categorias: $("#filtroLivCategorias").val(),
            IncluiInativos: $("#filtroLivInativado").is(":checked"),
            PagAtual: pag
        });
    }
    if (tabela == "Categorias") {
        Pesquisar = urls.BuscarCategorias;
        filtros = JSON.stringify({
            Id: $("#filtroCatId").val(),
            Nome: $("#filtroCatNome").val(),
            IncluiInativados: $("#filtroCatInativados").is(":checked"),
            PagAtual: pag
        });
    }
    if (tabela == "Grupos") {
        Pesquisar = urls.BuscarGrupos;
        filtros = JSON.stringify({
            Id: $("#filtroGrpId").val(),
            Nome: $("#filtroGrpNome").val(),
            IncluiInativo: $("#filtroGrpInativo").is(":checked"),
            MargemMax: $("#filtroGrpMargemMax").val(),
            MargemMin: $("#filtroGrpMargemMin").val(),
            PagAtual: pag
        });

    }
    if (tabela == "Codigos") {
        Pesquisar = urls.BuscarCodigo;
        filtros = JSON.stringify({
            Id: $("#filtroCodId").val(),
            Codigo: $("#filtroCodNome").val(),
            IncluiInativo: $("#filtroCodInativados").is(":checked"),
            ValorMax: $("#filtroCodValorMax").val(),
            ValorMin: $("#filtroCodValorMin").val(),
            PagAtual: pag
        });

    }

    divTabela.load(Pesquisar,
        {
            json: filtros
        }, function () {
            criaTriggers();

            $('.btnBuscarLiv').unbind('click');
            $('.btnPageLiv').unbind('click');
            $('.btnBuscarCat').unbind('click');
            $('.btnPageCat').unbind('click');
            $('.btnBuscarGrp').unbind('click');
            $('.btnPageGrp').unbind('click');
            $('.btnBuscarCod').unbind('click');
            $('.btnPageCod').unbind('click');

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

            $(".btnBuscarCod").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1, "Codigos");
            });

            $(".btnPageCod").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag, "Codigos");
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

$(".btnBuscarCod").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1, "Codigos");
});

$(".btnPageCod").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag, "Codigos");
});