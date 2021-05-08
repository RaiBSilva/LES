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
        soma += Number($(this).val());
    })

    $("#valSoma").html("R$" + soma);
    if (soma == $("#ValorTotal").val()) {
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
