function atualizarLista(pag) {
    if (pag === undefined) pag = 1;

    var divLoja = $("#divLoja");

    var titulo = $("#Filtros_Titulo").val();
    var autor = $("#Filtros_Autor").val();
    var isbn = $("#Filtros_Isbn").val();
    var editora = $("#Filtros_Editora").val();
    var precoMin = $("#Filtros_PrecoMin").val();
    var precoMax = $("#Filtros_PrecoMax").val();
    var dataMin = $("#Filtros_DataMin").val();
    var dataMax = $("#Filtros_DataMax").val();
    var categorias = $("#Filtros_Categorias").val();

    var filtros = JSON.stringify({
        Titulo: titulo,
        Autor: autor,
        Isbn: isbn,
        Editora: editora,
        PrecoMin: precoMin,
        PrecoMax: precoMax,
        DataMin: dataMin,
        DataMax: dataMax,
        Categorias: categorias,
        PaginaAtual: pag
    });
    divLoja.load(urls.Pesquisar,
        {
            filtro: filtros
        });
};

$(".btnFazerPesquisa").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1);
});

$(".btnPage").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag);
});