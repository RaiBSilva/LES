function adicionarEndereco(tipo, div) {

    var newDivEndereco = document.createElement("div");
    newDivEndereco.className = "endereco";
    div.insertBefore(newDivEndereco, div.lastChild)

    var newHeader = document.createElement("h2");
    newHeader.innerHTML = "Endereço" + div.childElementCount;
    newDivEndereco.appendChild(newHeader);

    var newDivTipoEndereco = document.createElement("div");
    newDivTipoEndereco = "form-group";

}