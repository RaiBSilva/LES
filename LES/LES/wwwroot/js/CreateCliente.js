function containsLowerCase(str) {
    for (var i = 0; i < str.length; i++) {
        if (str.charAt(i) == str.charAt(i).toLowerCase()) {
            return true;
        }
    }
    return false;
}

function containsUpperCase(str) {
    for (var i = 0; i < str.length; i++) {
        if (str.charAt(i) == str.charAt(i).toUpperCase()) {
            return true;
        }
    }
    return false;
}

function containsSpecialChar(str) {

    var format = /[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
}

document.getElementById("senha").addEventListener("input", function (e) {

    var senhaValor = document.getElementById("senha").value;

    var isValid = false;

    if (((senhaValor.length >= 8) && (containsLowerCase(senhaValor))) && ((containsUpperCase(senhaValor))) && (containsSpecialChar(senhaValor))) {
        document.getElementById("senha").style.borderColor = "green";
    } else {
        document.getElementById("senha").style.borderColor = "red";
    }

});