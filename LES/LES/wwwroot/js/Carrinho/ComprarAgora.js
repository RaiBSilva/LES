function comprarAgora(codBar) {
    var quantia = 1;

    $.ajax({
        url: urls.AddCarrinho,
        method: 'POST',
        dataType: 'json',
        data: { codBar: codBar, quantia: quantia },
        beforeSend: desativarBtns(),
        success: function (dados) {
            if (dados.valor == true) carregarCarrinho("Feito!", "alert-success");
            else carregarCarrinho(dados.msg, "alert-danger");
            window.location.href = urls.FinalizarCompra;
        },
        complete: function () {
            reativarBtns();
        }
    })
};

$(".comprarAgora").on("click", function (e) {
    var codBar = this.value;
    comprarAgora(codBar);
});