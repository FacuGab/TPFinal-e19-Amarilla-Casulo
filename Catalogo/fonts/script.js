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


const toastTrigger = document.getElementById('liveToastBtn')
const toastLiveExample = document.getElementById('liveToast')

if (toastTrigger) {
    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
    toastTrigger.addEventListener('click', () => {
        toastBootstrap.show()
    })
}