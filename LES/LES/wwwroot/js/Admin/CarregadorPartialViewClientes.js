function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-xl";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}

function carregarInativarCliente(id) {
    var endereco = urls.InativarReativarCliente + "?id=" + id;
    carregarPartialView(endereco);
}

function carregarVisualizarCliente(id) {
    var endereco = urls.VisualizarCliente + "?id=" + id;
    carregarPartialView(endereco);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

$(".btnInativar").on("click", function (e) {
    var id = $(this).val();
    carregarInativarCliente(id);
});

$(".btnVisualizar").on("click", function (e) {
    var id = $(this).val();
    carregarVisualizarCliente(id);
});