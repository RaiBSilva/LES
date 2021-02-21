function apagarEndereco(e) {

    e.preventDefault();

    var btnApagar = e.target;
    var divEndereco = btnApagar.parentNode;
    var divTodosEnderecos = divEndereco.parentNode;
    var index = Array.prototype.indexOf.call(divTodosEnderecos.children, divEndereco);

    var tipo = divTodosEnderecos.id;

    divEndereco.remove();

    var numChildNodes = divTodosEnderecos.childElementCount;

    for (i = index; i < numChildNodes; i++) {
        var div = divTodosEnderecos.children[i];

        //HeaderID
        div.firstChild.id = "header" + tipo + (i + 1);;
        //HeaderInnerHTML
        div.firstChild.innerHTML = "Endereço " + (i + 1);

        //Label TipoEndereco
        div.children[2].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__TipoEndereco");
        //Select TipoEndereco
        div.children[2].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (i) + "].TipoEndereco");
        div.children[2].children[1].id = "Enderecos" + tipo + "_" + (i) + "__TipoEndereco";

        //Label Logradouro
        div.children[3].firstChild.firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Logradouro");
        //Input Logradouro
        div.children[3].firstChild.children[1].id = "Enderecos" + tipo + "_" + (i) + "__Logradouro";
        div.children[3].firstChild.children[1].setAttribute("name", "Enderecos" + tipo + "[" + (i) + "].Logradouro");

        //Label Numero
        div.children[3].children[1].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Numero");
        //Input Numero
        div.children[3].children[1].children[1].id = "Enderecos" + tipo + "_" + (i) + "__Numero";
        div.children[3].children[1].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (i) + "].Numero");

        //Label Complemento
        div.children[4].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Complemento");
        //Input Complemento
        div.children[4].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (i) + "].Complemento");
        div.children[4].children[1].id = "Enderecos" + tipo + "_" + (i) + "__Complemento";

        //Label Cep
        div.children[5].firstChild.firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Cep");
        //Input Cep
        div.children[5].firstChild.children[1].setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cep");
        div.children[5].firstChild.children[1].id = "Enderecos" + tipo + "_" + (i) + "__Cep";

        //Label Cidade
        div.children[5].children[1].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Cidade");
        //Input Cidade
        div.children[5].children[1].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cidade.Nome");
        div.children[5].children[1].children[1].id = "Enderecos" + tipo + "_" + (i) + "__Cidade_Nome";

        //Label Estado
        div.children[5].children[2].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Cidade_Estado");
        //Input Estado
        div.children[5].children[2].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cidade.Estado.Nome");
        div.children[5].children[2].children[1].id = "Enderecos" + tipo + "_" + (i) + "__Cidade_Estado_Nome";

        //Label Pais
        div.children[5].children[3].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Cep");
        //Input Pais
        div.children[5].children[3].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cep");
        div.children[5].children[3].children[1].id = "Enderecos" + tipo + "_" + (i) + "__Cep";

        //Label Observacoes
        div.children[6].firstChild.setAttribute("for", "Enderecos" + tipo + "_" + (i) + "__Observacoes");
        //Select Observacoes
        div.children[6].children[1].setAttribute("name", "Enderecos" + tipo + "[" + (i) + "].Observacoes");
        div.children[6].children[1].id = "Enderecos" + tipo + "_" + (i) + "__Observacoes";

    }

}

function adicionarEndereco(e, tipo) {

    e.preventDefault();

    var div = document.getElementById(tipo);
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
    btn.className = "btn btn-rmv";
    btnApagar.addEventListener("click", function (e2) {
        apagarEndereco(e2);
    })
    newDivEndereco.appendChild(btnApagar);

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

    //CEP CIDADE ESTADO PAIS
    var newDivCepCidadeEstadoPais = document.createElement("div");
    newDivCepCidadeEstadoPais.className = "form-group";
    newDivEndereco.appendChild(newDivCepCidadeEstadoPais);

    //CEP
    var newDivCep = document.createElement("div");
    newDivCep.className = "form-group cidadeCepEstado";
    newDivCepCidadeEstadoPais.appendChild(newDivCep);

    var labelCep = document.createElement("label");
    labelCep.className = "control-label";
    labelCep.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Cep");
    labelCep.innerHTML = document.getElementById("labelCep").innerHTML;
    newDivCep.appendChild(labelCep);

    var inputCep = document.createElement("input");
    inputCep.className = "form-control";
    inputCep.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cep");
    inputCep.id = "Enderecos" + tipo + "_" + (index) + "__Cep";
    newDivCep.appendChild(inputCep);

    //CIDADE
    var newDivCidade = document.createElement("div");
    newDivCidade.className = "form-group cidadeCepEstado";
    newDivCepCidadeEstadoPais.appendChild(newDivCidade);

    var labelCidade = document.createElement("label");
    labelCidade.className = "control-label";
    labelCidade.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Cidade");
    labelCidade.innerHTML = document.getElementById("labelCidade").innerHTML;
    newDivCidade.appendChild(labelCidade);

    var inputCidade = document.createElement("input");
    inputCidade.className = "form-control";
    inputCidade.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cidade.Nome");
    inputCidade.id = "Enderecos" + tipo + "_" + (index) + "__Cidade_Nome";
    newDivCidade.appendChild(inputCidade);

    //ESTADO
    var newDivEstado = document.createElement("div");
    newDivEstado.className = "form-group estado";
    newDivCepCidadeEstadoPais.appendChild(newDivEstado);

    var labelEstado = document.createElement("label");
    labelEstado.className = "control-label";
    labelEstado.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Cidade_Estado");
    labelEstado.innerHTML = document.getElementById("labelEstado").innerHTML;
    newDivEstado.appendChild(labelEstado);

    var inputEstado = document.createElement("input");
    inputEstado.className = "form-control";
    inputEstado.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cidade.Estado.Nome");
    inputEstado.id = "Enderecos" + tipo + "_" + (index) + "__Cidade_Estado_Nome";
    newDivEstado.appendChild(inputEstado);

    //PAIS
    var newDivPais = document.createElement("div");
    newDivPais.className = "form-group";
    newDivCepCidadeEstadoPais.appendChild(newDivPais);

    var labelPais = document.createElement("label");
    labelPais.className = "control-label";
    labelPais.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Cidade_Estado_Pais");
    labelPais.innerHTML = document.getElementById("labelEstado").innerHTML;
    newDivPais.appendChild(labelPais);

    var inputPais = document.createElement("input");
    inputPais.className = "form-control";
    inputPais.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Cidade.Estado.Pais.Nome");
    inputPais.id = "Enderecos" + tipo + "_" + (index) + "__Cidade_Estado_Pais_Nome";
    newDivPais.appendChild(inputPais);

    //OBSERVACOES

    var newDivObservacoes = document.createElement("div");
    newDivObservacoes.className = "form-group";
    newDivEndereco.appendChild(newDivObservacoes);

    var labelObservacoes = document.createElement("label");
    labelObservacoes.className = "control-label";
    labelObservacoes.setAttribute("for", "Enderecos" + tipo + "_" + (index) + "__Observacoes");
    labelObservacoes.innerHTML = document.getElementById("labelObservacoes").innerHTML;
    newDivObservacoes.appendChild(labelObservacoes);

    var inputObservacoes = document.createElement("input");
    inputObservacoes.className = "form-control";
    inputObservacoes.setAttribute("name", "Enderecos" + tipo + "[" + (index) + "].Observacoes");
    inputObservacoes.id = "Enderecos" + tipo + "_" + (index) + "__Observacoes";
    newDivObservacoes.appendChild(inputObservacoes);

    div.insertBefore(newDivEndereco, div.children[(index)]);
}

document.getElementById("btnAddCobranca").addEventListener("click", function (e) {
    adicionarEndereco(e, "Cobranca");
})

document.getElementById("btnAddEntrega").addEventListener("click", function (e) {
    adicionarEndereco(e, "Entrega");
})

document.getElementsByName("ApagarEndereco").addEventListener("click", function (e) {
    apagarEndereco(e);
})