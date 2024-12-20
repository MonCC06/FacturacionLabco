﻿
let dataTable;

$(document).ready(function () {
    loadDatatable();
});

function loadDatatable() {
    dataTable = $("#tblData").DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Cliente/ObtenerListaClientes"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "Nombre", "width": "15%" },
            { "data": "PrimerApellido", "width": "15%" },
            { "data": "SegundoApellido", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Orden/Detalle/${data}" class="btn btn-success text-white" style="cursor: pointer;">
                                <i class="fas fa-edit"></i>
                            </a>
                        </div>
                     `;
                }, "width": "5%"
            }
        ]
    });


}