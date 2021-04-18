function validaCampoNumerico(input, min) {

    if ( /^\d+$/.test($(input).val)) {

        if ($(input).val.length < min) {
            return true;
        }
        makeRed($(input));
        return false;
    }

    return false;
}