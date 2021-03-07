function verificaRequired(evt){

    var boolean = true;

    inputAlterado = evt.target;

    $(".required").each(function () {
        if ($(inputAlterado).val() == "") {
            $(inputAlterado).css('border-color', 'red')
            boolean = false;
        } else {
            $(inputAlterado).removeAttr("style");
        }
    });

    return boolean;

}

$(".required").on("input", function (evt) {
    desativarBotao(verificaRequired(evt));
});