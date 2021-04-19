function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-xl";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}


function carregarAprovarPedido(id) {
    var endereco = urls.AprovarPedido + "/" + id;
    carregarPartialView(endereco);
}

function carregarNegarPedido(id) {
    var endereco = urls.NegarPedido + "/" + id;
    carregarPartialView(endereco);
}

function carregarCancelarPedido(id) {
    var endereco = urls.CancelarPedido + "/" + id;
    carregarPartialView(endereco);
}

function carregarVisualizarPedido(id) {
    var endereco = urls.VisualizarPedido + "/" + id;
    carregarPartialView(endereco);
}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
});

$(".btnAprovar").on("click", function (e) {
    var id = $(this).val();
    carregarAprovarPedido(id);
});

$(".btnNegar").on("click", function (e) {
    var id = $(this).val();
    carregarNegarPedido(id);
});

$(".btnCancelar").on("click", function (e) {
    var id = $(this).val();
    carregarCancelarPedido(id);
});

$(".btnVisualizar").on("click", function (e) {
    var id = $(this).val();
    carregarVisualizarPedido(id);
});