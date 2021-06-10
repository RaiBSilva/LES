function updateValor(id, checked) {
    var inputValor = $('input[name="Cartoes[' + id + '].Valor"]');

    if (checked) {
        $(inputValor).prop('disabled', false);
    } else {
        $(inputValor).prop('disabled', true);
        $(inputValor).val("");
    }
}

function somaValores(){

    soma = 0;

    $(".valorInput:enabled").each(function () {
        soma += parseFloat($(this).val());
    })

    $("#valSoma").html(parseFloat(soma).toFixed(2).toString().replace(".",","));
    if (soma == parseFloat($("#ValorTotal").val())) {
        $("#btnAlteraPag").prop('disabled', false);
    } else {
        $("#btnAlteraPag").prop('disabled', true);
    }
 }

function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-lg";

    $(newDivForm).load(endereco, function () {

        $(".cartaoCheckBox").change(function () {

            var check = false;
            if (this.checked) {
                check = true;
            }
            var nome = this.getAttribute("name");
            var id = nome.substring(nome.lastIndexOf("[") + 1,
                nome.lastIndexOf("]"));
            updateValor(id, check);
            somaValores();
        });
        $(".valorInput").on("input", somaValores);

    });
    divModal.appendChild(newDivForm);
}

function carregarAddEndereco() {
    carregarPartialView(urls.SelecionarEndereco);
}

function carregarAddCartao() {
    carregarPartialView(urls.SelecionarCartao);
}

function carregarUsarCupom() {
    carregarPartialView(urls.UsarCupom);
}

function carregarUsarCodigo(codigo) {
    carregarPartialView(urls.UsarCodigo + "?cod=" + codigo);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

$(".addEndereco").on("click", function (e) {
    carregarAddEndereco();
});

$(".addCartao").on("click", function (e) {
    carregarAddCartao();
});

$(".btnCupom").on("click", function (e) {
    carregarUsarCupom();
});

$(".btnCodigo").on("click", function (e) {
    var codigo = document.getElementById("inputCodigo").value;
    if (codigo == "") {
        $(".inputCodigo").css('border-color', 'red');
        $('#myModal').modal('toggle');
    }
    else {
        $(".inputCodigo").removeAttr("style");
        carregarUsarCodigo(codigo);
    }
});
