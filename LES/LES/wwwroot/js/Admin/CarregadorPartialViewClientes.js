function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-xl";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}

function carregarInativarCliente(id) {
    var endereco = urls.InativarReativarCliente + "/" + id;
    carregarPartialView(endereco);
}

$(".btnInativar").on("click", function (e) {
    var id = $(this).val();
    carregarInativarCliente(id);
});