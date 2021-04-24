function addCarrinho(codBar, quantia) {
    if (quantia === undefined) quantia = 1;

    $.ajax({
        url: urls.AddCarrinho,
        method: 'POST',
        dataType: 'json',
        data: { codBar: codBar , quantia: quantia},
        beforeSend: desativarBtns(),
        success: function (dados) {
            if (dados.valor == true) carregarCarrinho("Feito!", "alert-success");
            else carregarCarrinho(dados.msg, "alert-danger");
        },
        complete: reativarBtns()
    })
};

$(".addToCarrinho").on("click", function (e) {
    var codBar = this.value;
    addCarrinho(codBar);
});