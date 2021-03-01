function desativarBotao(naoTemVazios) {

    var botaoCadastro = document.getElementById("btn");

    if (naoTemVazios && confirmaSenha) {
        botaoCadastro.disabled = false;
    } else {
        botaoCadastro.disabled = true;
    }

}