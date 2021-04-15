$(".requiredForm").one("submit", function (e) {
    e.preventDefault();

    var camposObrigatorios = $(".required");

    $.ajax({
        method: "POST",
        url: urls.ChecarEmail,
        data: { email: emailAChecar },
        dataType: 'json',
        success: function (dados) {
            if ((validaCampos(camposObrigatorios) && (validaSenha())) && (dados.valor == false)) $(this).submit();
            else makeRed($(".email"));
        }
    });
});