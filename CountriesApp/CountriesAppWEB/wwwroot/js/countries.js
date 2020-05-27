﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url" : "/countries/GetAllCountries",
            "type": "GET",
            "datatype": "json"
        },
        "columns":
            [
                { "data": "name", "width": "20%" },
                { "data": "capital", "width": "20%" },
                { "data": "region", "width": "10%" },
                { "data": "area", "width": "10%" },
                { "data": "population", "width": "10%" },
                {
                    "data": "id",
                    "render": function (data) {
                        return `<div class="text-center">
                                <a href="/countries/Upsert/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>

                                <a onclick=Delete("/countries/Delete/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>`
                    }, "width": "10%"
                }
            ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}