function checaEmail(emailAChecar) {

    $.ajax({
        method: "POST",
        url: urls.ChecarEmail,
        data: { email: emailAChecar },
        dataType: 'json',
        success: function (dados) {
            if (dados.valor == false) makeGreen($(".email"));
            else makeRed($(".email"));
        }
    });

}

function validaEmail() { 

    var inputEmail = $(".email");
    var valueEmail = String(document.getElementById("InfoUsuario_Email").value);
    var format = /\S+@\S+/;

    if (format.test(valueEmail)) checaEmail(valueEmail);
    else {
        makeRed(inputEmail);
        return false;
    }
}

$("#btnChecarEmail").on("click", function (e) {
    e.preventDefault();
    validaEmail();
});