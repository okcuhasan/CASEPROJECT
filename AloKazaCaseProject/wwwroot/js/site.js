loadVehicleRecords();

function loadVehicleRecords() {
    $.ajax({
        type: "GET",
        url: "/Vehicle/GetVehicle",
        dataType: "json",
        success: function (msg) {
            DrawTable(msg);
        }
    })
}

function DrawTable(response) {
    $("#tbodyid").empty();

    $.each(response, function (i, item) {
        var $tr = $('<tr id="' + item.id + '">').append(
            $('<td>').text(item.vehicleName),
            $('<td>').text(item.carBrand),
            $('<td>').text(item.accidentSituation),
            $('<td>').text(item.totalPrice),
            $('<td>').html('<button type="button" args="' + item.id + '" class="btn-edit btn btn-success">Edit</button>'),
            $('<td>').html('<button type="button" args="' + item.id + '" class="btn-delete btn btn-danger">Delete</button>')
        ).appendTo('#VehicleTable');
    });
}

$("#btnAdd").click(function () {
    if ($('#btnAdd').hasClass('btn-update')) {
        var id = $('#id').val();

        $.ajax({
            type: "POST",
            url: "/Vehicle/Edit",
            data: $('form').serialize(),
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            headers:
            {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (msg) {
                loadProductRecords();
                $("#btnAdd").removeClass('btn-update');
                $('#VehicleModel').modal('hide'); 
            }
        });
        location.reload();
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Vehicle/Create",
            data: $('form').serialize(),
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            headers:
            {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (msg) {
                location.reload();
                loadProductRecords();
                $('#VehicleModel').modal('hide'); 
            }
        });
    }
});



$(document).on('click', '.btn-edit', function () {
    var id = $(this).attr('args');
    $.ajax({
        type: "GET",
        url: "/Vehicle/Details",
        data: { "id": id },
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (msg) {
            $("#VehicleName").val(msg.vehicleName);
            $("#CarBrand").val(msg.carBrand);
            $("#AccidentSituation").val(msg.accidentSituation);
            $("#TotalPrice").val(msg.totalPrice);
            $("#id").val(msg.id);
            $("#btnAdd").addClass("btn-update");


            $('#VehicleModel').modal('show');
        }
    });
});

$(document).on('click', '.btn-delete', function () {
    var id = $(this).attr('args');
    $.ajax({
        type: "POST",
        url: "/Vehicle/Delete",
        data: { "id": id },
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (msg) {
            $('table#VehicleTable tr#' + id).remove();
        }
    });
});






    


