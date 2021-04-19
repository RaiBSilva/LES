$(".requiredForm").one("submit", function (e) {
    e.preventDefault();

    var camposObrigatorios = $(".required");

    if (validaCampos(camposObrigatorios) && (validaSenha()))
        if (validaCampoNumerico($("#Telefone_Ddd"), 3))
            if ((validaCampoNumerico($("#Endereco_Cep"), 7)))
                if ((validaCampoNumerico($("#Telefone_NumeroTelefone"), 7))){
                $.ajax({
                    method: "POST",
                    url: urls.ChecarEmail,
                    data: { email: emailAChecar },
                    dataType: 'json',
                    success: function (dados) {
                        if (dados.valor == false) {
                            $(this).submit();
                        }
                        else makeRed($(".email"));
                    }
                });
            }
});