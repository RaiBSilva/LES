function containsLowerCase(str) {
    return str.toUpperCase() != str;
}

function containsUpperCase(str) {
    return str.toLowerCase() != str;
}

function containsSpecialChar(str) {
    var format = /[ `!@#$%^&*()_+\-=\[\]{};':\\|,.<>\/?~]/;
    return format.test(str);
}

function confirmaSenha() {

    var senhaInput = document.getElementById("senha");
    var confirmaInput = document.getElementById("senhaConfirmacao");
    var btn = document.getElementById("btn");

    var senhaValor = senhaInput.value;
    var confirmaValor = confirmaInput.value;

    if (senhaValor == confirmaValor) {
        confirmaInput.style.borderColor = "green";
        btn.disabled = false;
    } else {
        confirmaInput.style.borderColor = "red";
        btn.disabled = true;
    }

}

document.getElementById("senha").addEventListener("input", function (e) {

    var senhaInput = document.getElementById("senha");
    var confirmaInput = document.getElementById("senhaConfirmacao");

    var requisitos = document.getElementById("requisitosSenha");
    var caracteres = document.getElementById("caracteres");
    var minusculas = document.getElementById("minusculas");
    var maiusculas = document.getElementById("maiusculas");
    var especiais = document.getElementById("especiais");

    var senhaValor = senhaInput.value;

    if (((senhaValor.length >= 8) && (containsLowerCase(senhaValor))) && ((containsUpperCase(senhaValor))) && (containsSpecialChar(senhaValor)))
    {
        confirmaInput.disabled = false;
        senhaInput.style.borderColor = "green";
        requisitos.style.color = "green";
        caracteres.style.color = "green";
        minusculas.style.color = "green";
        maiusculas.style.color = "green";
        especiais.style.color = "green";

    } else {
        confirmaInput.disabled = true;
        senhaInput.style.borderColor = "red";
        requisitos.style.color = "red";

        if (senhaValor.length < 8) {
            caracteres.style.color = "red";
        } else {
            caracteres.style.color = "green";
        }

        if (containsLowerCase(senhaValor)) {
            minusculas.style.color = "green";
        } else {
            minusculas.style.color = "red";
        }

        if (containsUpperCase(senhaValor)) {
            maiusculas.style.color = "green";
        } else {
            maiusculas.style.color = "red";
        }

        if (containsSpecialChar(senhaValor)) {
            especiais.style.color = "green";
        } else {
            especiais.style.color = "red";
        }

    }

    confirmaSenha();

});



document.getElementById("senhaConfirmacao").addEventListener("input", confirmaSenha);