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

    return (senhaValor == confirmaValor);

}

function validaSenha() {
    var senhaInput = document.getElementById("senha");
    var confirmaInput = document.getElementById("senhaConfirmacao");

    var requisitos = document.getElementById("requisitosSenha");
    var caracteres = document.getElementById("caracteres");
    var minusculas = document.getElementById("minusculas");
    var maiusculas = document.getElementById("maiusculas");
    var especiais = document.getElementById("especiais");

    var senhaValor = senhaInput.value;

    var boolCaracteres = senhaValor.length >= 8;
    var boolMinusculas = containsLowerCase(senhaValor);
    var boolMaiusculas = containsUpperCase(senhaValor);
    var boolEspeciais = containsSpecialChar(senhaValor);

    if (((boolCaracteres) && (boolMinusculas)) && ((boolMaiusculas)) && (boolEspeciais)) {
        senhaInput.style.borderColor = "green";
        requisitos.style.color = "green";
        caracteres.style.color = "green";
        minusculas.style.color = "green";
        maiusculas.style.color = "green";
        especiais.style.color = "green";
        return confirmaSenha();

    } else {
        senhaInput.style.borderColor = "red";
        requisitos.style.color = "red";

        if (boolCaracteres) {
            caracteres.style.color = "green";
        } else {
            caracteres.style.color = "red";
        }

        if (boolMinusculas) {
            minusculas.style.color = "green";
        } else {
            minusculas.style.color = "red";
        }

        if (boolMaiusculas) {
            maiusculas.style.color = "green";
        } else {
            maiusculas.style.color = "red";
        }

        if (boolEspeciais) {
            especiais.style.color = "green";
        } else {
            especiais.style.color = "red";
        }
    }
    return false;
}

document.getElementById("senha").addEventListener("input", function (e) {
    validaSenha();
});