$(".requiredForm").one("submit", function (e) {
    e.preventDefault();

    var camposObrigatorios = $(".required");

    if (validaCampos(camposObrigatorios) && (validaSenha())) {
        $.ajax({
            method: "POST",
            url: urls.ChecarEmail,
            data: { email: String(document.getElementById("InfoUsuario_Email").value) },
            dataType: 'json',
            success: function (dados) {
                if (dados.valor == false) {
                    $(".requiredForm").submit();
                }
                else makeRed($(".email"));
            }
        });
    }
});