function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-xl";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}

function carregarVisualizarPedido(id) {
    var endereco = urls.VisualizarPedido + "/" + id;
    carregarPartialView(endereco);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

$(".btnVisualizar").on("click", function (e) {
    var id = $(this).val();
    carregarVisualizarPedido(id);
});