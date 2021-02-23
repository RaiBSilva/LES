function correctSelect(div, i, string) {
    div.children[0].setAttribute("for", "Enderecos" + "_" + (i) + "__" + string);
    div.children[1].setAttribute("name", "Enderecos" + "[" + (i) + "]." + "__" + string);
    div.children[1].id = "Enderecos" + "_" + (i) + "__" + string;
}

function correctInput(div, i, string) {
    div.children[0].setAttribute("for", "Enderecos" + "_" + (i) + "__" + string);
    div.children[1].id = "Enderecos" + "_" + (i) + "__" + string;
    div.children[1].setAttribute("name", "Enderecos" + "[" + (i) + "]." + string);
}

function apagarEndereco(e) {

    e.preventDefault();

    var btnApagar = e.target;
    var divEndereco = btnApagar.parentElement ;
    var divTodosEnderecos = divEndereco.parentElement ;
    var index = Array.prototype.indexOf.call(divTodosEnderecos.children, divEndereco);

    var tipo = divTodosEnderecos.id;

    divEndereco.remove();

    var numChildNodes = divTodosEnderecos.childElementCount;
    if (index < numChildNodes-1){
        for (i = index; i < numChildNodes - 1; i++) {
            var div = divTodosEnderecos.children[parseInt(i)];

            //HeaderID
            div.firstElementChild.id = "header" + tipo + (i + 1);
            //HeaderInnerHTML
            div.firstElementChild.innerHTML = "Endereço " + (i + 1);

            //TipoEndereco
            correctSelect(div.children[2].children[0], i, "TipoEmdereco");

            //EEntrega
            correctInput(div.children[2].children[1].children[0], i, "EEntrega");

            //ECobranca
            correctInput(div.children[2].children[1].children[1], i, "ECobranca");

            //Logradouro
            correctInput(div.children[3].children[0], i, "Logradouro");

            //Numero
            correctInput(div.children[3].children[1], i, "Numero");

            //Complemento
            correctInput(div.children[4], i, "Complemento");

            //Cep
            correctInput(div.children[5].children[0], i, "Cep");

            //Cidade
            correctInput(div.children[5].children[1], i, "Cidade");

            //Estado
            correctInput(div.children[5].children[2], i, "Estado");

            //Pais
            correctInput(div.children[5].children[3], i, "Pais");

            //Observacoes
            correctInput(div.children[6], i, "Observacoes");

        }
    }
}

function setLabel(label, id, innerHtml, index) {

    label.className = "control-label";
    label.setAttribute("for", "Enderecos" + "_" + (index) + "__" + id);
    label.innerHTML = innerHtml;
    return label;

}

function setSelect(select, id, index) {
    select.className = "form-control";
    select.setAttribute("name", "Enderecos" + "[" + (index) + "]." + id);
    select.id = "Enderecos" + "_" + (index) + "__" + id;
    select.innerHTML = document.getElementById("Enderecos_0__" + id).innerHTML;
    return select;
}

function setInput(input, id, index) {
    input.className = "form-control";
    input.setAttribute("name", "Enderecos" + "[" + (index) + "]." + id);
    input.id = "Enderecos" + "_" + (index) + "__" + id;
    return input;
}

function adicionarEndereco(e, tipo) {

    e.preventDefault();

    var div = document.getElementById("enderecos");
    var index = div.childElementCount - 1;

    //DIV GERAL
    var newDivEndereco = document.createElement("div");
    newDivEndereco.className = "endereco";

    var newHeader = document.createElement("h4");
    newHeader.id = "header" + tipo + (index + 1);
    newHeader.innerHTML = "Endereço " + (index + 1);
    newDivEndereco.appendChild(newHeader);

    var btnApagar = document.createElement("button");
    btnApagar.innerHTML = "Apagar endereço";
    btn.className = "btn-rmv";
    btnApagar.addEventListener("click", function (e2) {
        apagarEndereco(e2);
    })
    newDivEndereco.appendChild(btnApagar);

    //TIPO DE ENDEREÇO E BOOLEANAS
    var newDivTipoEBooleanas = document.createElement("div");
    newDivTipoEBooleanas.className = "form-group";
    newDivEndereco.appendChild(newDivTipoEBooleanas);

    //TIPO ENDEREÇO
    var newDivTipoEndereco = document.createElement("div");
    newDivTipoEndereco.className = "form-group";
    newDivTipoEBooleanas.appendChild(newDivTipoEndereco);

    var labelTipoEndereco = document.createElement("label");
    labelTipoEndereco = setLabel(labelTipoEndereco, "TipoEndereco", "Tipo de Endereço", index)
    newDivTipoEndereco.appendChild(labelTipoEndereco);

    var selectTipoEndereco = document.createElement("select");
    selectTipoEndereco = setSelect(selectTipoEndereco, "TipoEndereco", index)
    newDivTipoEndereco.appendChild(selectTipoEndereco);

    //BOOLEANAS
    var newDivBooleanas = document.createElement("div");
    newDivBooleanas.className = "form-group";
    newDivEndereco.appendChild(newDivBooleanas);

    //É ENTREGA
    var newDivEEntrega = document.createElement("div");
    newDivBooleanas.appendChild(newDivEEntrega);

    var newLabelEEntrega = document.createElement("label");
    newLabelEEntrega = setLabel(newLabelEEntrega, "EEntrega", "É endereço de entrega?", index)
    newDivEEntrega.appendChild(newLabelEEntrega);

    var newInputEEntrega = document.createElement("input");
    newInputEEntrega = setInput(newInputEEntrega, "EEntrega", index);
    newInputEEntrega.setAttribute("type", "checkbox");
    newDivEEntrega.appendChild(newInputEEntrega);

    //É COBRANÇA
    var newDivECobranca = document.createElement("div");
    newDivBooleanas.appendChild(newDivECobranca);

    var newLabelECobranca = document.createElement("label");
    newLabelECobranca = setLabel(newLabelECobranca, "ECobranca", "É endereço de cobrança?", index)
    newDivECobranca.appendChild(newLabelECobranca);

    var newInputECobranca = document.createElement("input");
    newInputECobranca = setInput(newInputECobranca, "ECobranca", index);
    newInputECobranca.setAttribute("type", "checkbox");
    newDivECobranca.appendChild(newInputECobranca);

    //LOGRADOURO E NUMERO
    var newDivLogradouroNumero = document.createElement("div");
    newDivLogradouroNumero.className = "form-group";
    newDivEndereco.appendChild(newDivLogradouroNumero);

    //LOGRADOURO
    var newDivLogradouro = document.createElement("div");
    newDivLogradouro.className = "logradouro";
    newDivLogradouroNumero.appendChild(newDivLogradouro);

    var labelLogradouro = document.createElement("label");
    labelLogradouro = setLabel(labelLogradouro, "Logradouro", "Logradouro", index)
    newDivLogradouro.appendChild(labelLogradouro);

    var inputLogradouro = document.createElement("input");
    inputLogradouro = setInput(inputLogradouro, "Logradouro", index)
    newDivLogradouro.appendChild(inputLogradouro);

    //NUMERO
    var newDivNumero = document.createElement("div");
    newDivNumero.className = "numero";
    newDivLogradouroNumero.appendChild(newDivNumero);

    var labelNumero = document.createElement("label");
    labelNumero = setLabel(labelNumero, "Numero", "Nº", index);
    newDivNumero.appendChild(labelNumero);

    var inputNumero = document.createElement("input");
    inputNumero = setInput(inputNumero, "Numero", index)
    newDivNumero.appendChild(inputNumero);

    //COMPLEMENTO
    var newDivComplemento = document.createElement("div");
    newDivComplemento.className = "form-group";
    newDivEndereco.appendChild(newDivComplemento);

    var labelComplemento = document.createElement("label");
    labelComplemento = setLabel(labelComplemento, "Complemento", "Complemento", index);
    newDivComplemento.appendChild(labelComplemento);

    var inputComplemento = document.createElement("input");
    inputComplemento = setInput(inputComplemento, "Complemento", index)
    newDivComplemento.appendChild(inputComplemento);

    //CEP CIDADE ESTADO PAIS
    var newDivCepCidadeEstadoPais = document.createElement("div");
    newDivCepCidadeEstadoPais.className = "form-group";
    newDivEndereco.appendChild(newDivCepCidadeEstadoPais);

    //CEP
    var newDivCep = document.createElement("div");
    newDivCep.className = "form-group cidadeCepEstado";
    newDivCepCidadeEstadoPais.appendChild(newDivCep);

    var labelCep = document.createElement("label");
    labelComplemento = setLabel(labelComplemento, "Cep", "CEP", index);
    newDivCep.appendChild(labelCep);

    var inputCep = document.createElement("input");
    inputComplemento = setInput(inputComplemento, "Cep", index);
    newDivCep.appendChild(inputCep);

    //CIDADE
    var newDivCidade = document.createElement("div");
    newDivCidade.className = "form-group cidadeCepEstado";
    newDivCepCidadeEstadoPais.appendChild(newDivCidade);

    var labelCidade = document.createElement("label");
    labelCidade = setLabel(labelCidade, "Cidade", "Cidade", index);
    newDivCidade.appendChild(labelCidade);

    var inputCidade = document.createElement("input");
    inputComplemento = setInput(inputComplemento, "Cidade", index);
    newDivCidade.appendChild(inputCidade);

    //ESTADO
    var newDivEstado = document.createElement("div");
    newDivEstado.className = "form-group estado";
    newDivCepCidadeEstadoPais.appendChild(newDivEstado);

    var labelEstado = document.createElement("label");
    labelEstado = setLabel(labelEstado, "Estado", "Estado", index);
    newDivEstado.appendChild(labelEstado);

    var inputEstado = document.createElement("input");
    inputEstado = setInput(inputEstado, "Estado", index);
    newDivEstado.appendChild(inputEstado);

    //PAIS
    var newDivPais = document.createElement("div");
    newDivPais.className = "form-group";
    newDivCepCidadeEstadoPais.appendChild(newDivPais);

    var labelPais = document.createElement("label");
    labelPais = setLabel(labelPais, "Pais", "País", index);
    newDivPais.appendChild(labelPais);

    var inputPais = document.createElement("input");
    inputPais = setInput(inputPais, "Pais", index);
    newDivPais.appendChild(inputPais);

    //OBSERVACOES
    var newDivObservacoes = document.createElement("div");
    newDivObservacoes.className = "form-group";
    newDivEndereco.appendChild(newDivObservacoes);

    var labelObservacoes = document.createElement("label");
    labelObservacoes = setLabel(labelObservacoes, "Observacoes", "Observações", index);
    newDivObservacoes.appendChild(labelObservacoes);

    var inputObservacoes = document.createElement("input");
    inputObservacoes = setInput(inputObservacoes, "Observacoes", index);
    newDivObservacoes.appendChild(inputObservacoes);

    div.insertBefore(newDivEndereco, div.children[(index)]);
}

document.getElementById("btnAddEndereco").addEventListener("click", function (e) {
    adicionarEndereco(e, "Cobranca");
})

var btnsApagar = document.getElementsByName("ApagarEndereco");

for (i = 0; i < btnsApagar.length; i++) {
    btnsApagar[i].addEventListener("click", function (e) {
        apagarEndereco(e);
    });
}