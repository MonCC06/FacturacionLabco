$(document).ready(function () {
    $('#FormVehi').on('submit', function (e) {
        e.preventDefault(); // Evita el submit normal

        var formData = $(this).serialize(); // Convierte los inputs en una cadena de consulta

        $.ajax({
            url: '/Vehiculo/Upsert',
            type: 'POST',
            data: formData,
            success: function (response) {
                console.log("Respuesta del servidor:", response);
                alert("Vehículo guardado con éxito.");
                // Puedes redirigir o limpiar el formulario aquí
            },
            error: function (xhr) {
                console.error("Error al guardar:", xhr.responseText);
                alert("Ocurrió un error al guardar el vehículo.");
            }
        });
    });
});