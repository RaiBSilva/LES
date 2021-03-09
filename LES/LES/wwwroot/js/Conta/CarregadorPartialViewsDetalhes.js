function carregarPartialView(endereco) {

    var divModal = document.getElementById("myModal");
    var newDivForm = document.createElement("div");
    newDivForm.className = "modal-dialog modal-sm";

    $(newDivForm).load(endereco);
    divModal.appendChild(newDivForm);
}

function carregarNovoEndereco() {

    carregarPartialView(urls.novoEndereco);

}

$('#myModal').on('hidden.bs.modal', function () {
    $(this).empty();
})

document.getElementById("addNovoEnderecoLink").addEventListener("click", function (e) {
    carregarNovoEndereco();
});