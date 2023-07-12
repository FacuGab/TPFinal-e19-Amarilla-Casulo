function mostrarAlerta(text) {
    alert(text);
}

function mostrarDiv(text) {
    var div = document.getElementById(text);
    div.style.display = 'block';
}

function validarSoloNumeros(elemento) {
    var valor = elemento.value.trim();

    if (valor.length === 0 || isNaN(valor)) {
        alert('Ingresa solo números.');
        elemento.focus();
        return false;
    }

    return true;
}

document.addEventListener('DOMContentLoaded', function () {
    var btnAgregar = document.getElementById('<%= btnAgregar.ClientID %>');
    var toast = document.getElementById('toast');

    btnAgregar.addEventListener('click', function () {
        toast.classList.add('show');
        setTimeout(function () {
            toast.classList.remove('show');
        }, 5000); // Ocultar el toast después de 5 segundos
    });
});
