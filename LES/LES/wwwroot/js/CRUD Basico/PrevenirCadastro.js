function desativarBotao(naoTemVazios) {

    var botaoCadastro = document.getElementById("btn");

    if (naoTemVazios) {
        botaoCadastro.disabled = false;
    } else {
        botaoCadastro.disabled = true;
    }

}