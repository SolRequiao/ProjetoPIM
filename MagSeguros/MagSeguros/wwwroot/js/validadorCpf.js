function ValidaCPF(cpfEnviado) {
    Object.defineProperty(this, 'cpfLimpo', {
        enumerable: true,
        get: function () {
            return cpfEnviado.replace(/\D+/g, '');
        }
    });
}

ValidaCPF.prototype.valida = function () {
    if (typeof this.cpfLimpo === 'undefined') return false;
    if (this.cpfLimpo.length !== 11) return false;
    if (this.eUmaSequencia()) return false;

    const cpfParcial = this.cpfLimpo.slice(0, -2);
    const digito1 = this.validaDigito(cpfParcial);
    const digito2 = this.validaDigito(cpfParcial + digito1);
    const cpfValidado = cpfParcial + digito1 + digito2;

    return cpfValidado === this.cpfLimpo;
}

ValidaCPF.prototype.validaDigito = function (cpfParcial) {
    const cpfArray = Array.from(cpfParcial);
    let regressivo = cpfArray.length + 1;
    const total = cpfArray.reduce((acumulador, valor) => {
        acumulador += (regressivo * Number(valor));
        regressivo--;
        return acumulador
    }, 0)
    const digito = 11 - (total % 11);
    return digito > 9 ? '0' : String(digito);
}

ValidaCPF.prototype.eUmaSequencia = function () {
    const sequencia = this.cpfLimpo[0].repeat(this.cpfLimpo.length)
    return sequencia === this.cpfLimpo;
}

ValidaCPF.prototype.mascara = function (cpf) {

    var valor = cpf.value;

    if (isNaN(valor[valor.length - 1])) {
        cpf.value = valor.substring(0, valor.length - 1);
        return;
    }

    cpf.setAttribute("maxlength", "14");
    if (valor.length == 3 || valor.length == 7) cpf.value += ".";
    if (valor.length == 11) cpf.value += "-";
}


document.addEventListener('click', (e) => {
    const elemento = e.target;
    const inserirCPF = document.querySelector('#cpf');

    const cpf = new ValidaCPF(inserirCPF.value);
    if (elemento.classList.contains('btn-primary')) {
        if (cpf.valida()) {
        } else {
            alert(`O CPF do segurado é invaliado!`);
            e.preventDefault();
        }
    }
});

