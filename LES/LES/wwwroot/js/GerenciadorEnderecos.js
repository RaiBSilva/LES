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
    btn.className = "btn-danger";
    btnApagar.addEventListener("click", function (e2) {
        apagarEndereco(e2);
    })
    newDivEndereco.appendChild(btnApagar);

    //Div do formulário:
    var newDivForm = document.createElement("div");

    $(newDivForm).load(cadastro.urls.endereco + "/" + (div.childElementCount - 1));
    newDivEndereco.appendChild(newDivForm);

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