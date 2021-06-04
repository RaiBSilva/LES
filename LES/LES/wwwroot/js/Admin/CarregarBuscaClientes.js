function atualizarLista(pag) {
    if (pag === undefined) pag = 1;

    var divTabela = $("#divTabela");

    var Pesquisar = urls.BuscarClientes;

    var filtros = JSON.stringify({
        Id: $("#filtroId")[0].value,
        Nome: $("#filtroNome")[0].value,
        Email: $("#filtroEmail")[0].value,
        IncluiInativo: $("#filtroInativos").is(":checked"),
        PagAtual: pag
    });
    divTabela.load(Pesquisar,
        {
            filtro: filtros
        }, function () {
            $(".btnBuscar").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1);
            });

            $(".btnPage").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag);
            });

            $(".btnInativar").on("click", function (e) {
                var id = $(this).val();
                carregarInativarCliente(id);
            });

            $(".btnVisualizar").on("click", function (e) {
                var id = $(this).val();
                carregarVisualizarCliente(id);
            });

        });
};

$(".btnBuscar").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1);
});

$(".btnPage").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag);
});
