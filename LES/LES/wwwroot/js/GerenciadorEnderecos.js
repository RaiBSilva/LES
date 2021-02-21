function adicionarEndereco(tipo) {

    var div = document.getElementById(tipo);
    var index = div.childElementCount - 1;

    //DIV GERAL
    var newDivEndereco = document.createElement("div");
    newDivEndereco.className = "endereco";

    var newHeader = document.createElement("h4");
    newHeader.id = "header" + tipo + index;
    newHeader.innerHTML = "Endereço" + index;
    newDivEndereco.appendChild(newHeader);

    //TIPO ENDEREÇO
    var newDivTipoEndereco = document.createElement("div");
    newDivTipoEndereco.className = "form-group";
    newDivEndereco.appendChild(newDivTipoEndereco);

    var labelTipoEndereco = document.createElement("label");
    labelTipoEndereco.className = "control-label";
    labelTipoEndereco.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__TipoEndereco");
    labelTipoEndereco.innerHTML = document.getElementById("labelTipo").innerHTML;
    newDivTipoEndereco.appendChild(labelTipoEndereco);

    var selectTipoEndereco = document.createElement("select");
    selectTipoEndereco.className = "form-control";
    selectTipoEndereco.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].TipoEndereco");
    selectTipoEndereco.id = "Enderecos" + tipo + "_" + (index) + "__TipoEndereco";
    selectTipoEndereco.innerHTML = document.getElementById("EnderecoResidencia_TipoEndereco").innerHTML;
    newDivTipoEndereco.appendChild(selectTipoEndereco);

    //LOGRADOURO E NUMERO
    var newDivLogradouroNumero = document.createElement("div");
    newDivLogradouroNumero.className = "form-group";
    newDivEndereco.appendChild(newDivLogradouroNumero);

    //LOGRADOURO
    var newDivLogradouro = document.createElement("div");
    newDivLogradouro.className = "logradouro";
    newDivLogradouroNumero.appendChild(newDivLogradouro);

    var labelLogradouro = document.createElement("label");
    labelLogradouro.className = "control-label";
    labelLogradouro.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Logradouro");
    labelLogradouro.innerHTML = document.getElementById("labelLogradouro").innerHTML;
    newDivLogradouro.appendChild(labelLogradouro);

    var inputLogradouro = document.createElement("input");
    inputLogradouro.className = "form-control";
    inputLogradouro.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Logradouro");
    inputLogradouro.id = "Enderecos" + tipo + "_" + (index) + "__Logradouro";
    newDivLogradouro.appendChild(inputLogradouro);

    //NUMERO
    var newDivNumero = document.createElement("div");
    newDivNumero.className = "numero";
    newDivLogradouroNumero.appendChild(newDivNumero);

    var labelNumero = document.createElement("label");
    labelNumero.className = "control-label";
    labelNumero.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Numero");
    labelNumero.innerHTML = document.getElementById("labelNumero").innerHTML;
    newDivNumero.appendChild(labelNumero);

    var inputNumero = document.createElement("input");
    inputNumero.className = "form-control";
    inputNumero.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Numero");
    inputNumero.id = "Enderecos" + tipo + "_" + (index) + "__Numero";
    newDivNumero.appendChild(inputNumero);

    //COMPLEMENTO
    var newDivComplemento = document.createElement("div");
    newDivComplemento.className = "form-group";
    newDivEndereco.appendChild(newDivComplemento);

    var labelComplemento = document.createElement("label");
    labelComplemento.className = "control-label";
    labelComplemento.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Complemento");
    labelComplemento.innerHTML = document.getElementById("labelComplemento").innerHTML;
    newDivComplemento.appendChild(labelComplemento);

    var inputComplemento = document.createElement("input");
    inputComplemento.className = "form-control";
    inputComplemento.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Complemento");
    inputComplemento.id = "Enderecos" + tipo + "_" + (index) + "__Complemento";
    newDivComplemento.appendChild(inputComplemento);

    div.insertBefore(newDivEndereco, div.lastChild);

}