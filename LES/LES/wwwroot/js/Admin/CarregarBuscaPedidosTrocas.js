function atualizarLista(pag, tabela) {
    if (pag === undefined) pag = 1;

    var divTabela = $("#" + tabela);

    var trigrama = tabela.substring(0, 3);

    var Pesquisar = tabela == "Pedidos" ? urls.BuscarPedidos : urls.BuscarTrocas;

    var filtros = JSON.stringify({
        Id: $("#filtro"+ trigrama +"Id").val(),
        Nome: $("#filtro" + trigrama + "Cliente").val(),
        PrecoMin: $("#filtro" + trigrama + "DataMin").val(),
        PrecoMax: $("#filtro" + trigrama + "DataMax").val(),
        DataMin: $("#filtro" + trigrama + "ValorMin").val(),
        DataMax: $("#filtro" + trigrama + "ValorMin").val(),
        Status: $("#filtro" + trigrama + "Status").val(),
        PaginaAtual: pag
    });
    divTabela.load(Pesquisar,
        {
            filtro: filtros
        }, function () {
            $('.btnBuscarPedido').unbind('click');
            $('.btnPagePed').unbind('click');
            $('.btnBuscarTroca').unbind('click');
            $('.btnPageTro').unbind('click');


            $(".btnVisualizarPedido").unbind('click');
            $(".btnVisualizarTroca").unbind('click');

            $(".btnVisualizarPedido").on("click", function (e) {
                var id = $(this).val();
                carregarVisualizarPedido(id);
            });

            $(".btnVisualizarTroca").on("click", function (e) {
                var id = $(this).val();
                carregarVisualizarTroca(id);
            });

            $(".btnBuscarPedido").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1, "Pedidos");
            });

            $(".btnPagePed").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag, "Pedidos");
            });

            $(".btnBuscarTroca").on("click", function (e) {
                e.preventDefault();
                atualizarLista(1, "Trocas");
            });

            $(".btnPageTro").on("click", function (e) {
                var pag = $(this).val();
                atualizarLista(pag, "Trocas");
            });
        });
};

$(".btnBuscarPedido").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1, "Pedidos");
});

$(".btnPagePed").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag, "Pedidos");
});

$(".btnBuscarTroca").on("click", function (e) {
    e.preventDefault();
    atualizarLista(1, "Trocas");
});

$(".btnPageTro").on("click", function (e) {
    var pag = $(this).val();
    atualizarLista(pag, "Trocas");
});