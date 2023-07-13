$(document).ready(function () {
    // Guardar el id del elemento colapsable al hacer clic
    document.getElementById('btnAgregarArtAcordion').onclick(function () {
        localStorage.setItem('collapse_One', $(this).attr('collapseOne'));
        console.log("collapse_One");
    });

    // Obtener el id del elemento colapsable
    var collapseItem = localStorage.getItem('collapse_One');
    if (collapseItem) {
        // Abrir el elemento colapsable
        $(collapseItem).collapse('show')
    }
})
