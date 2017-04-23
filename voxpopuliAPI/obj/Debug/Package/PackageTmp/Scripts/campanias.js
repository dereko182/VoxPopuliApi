$(document).ready(function () {

    cargarGrid();

    var myWindow = $("#window");
    function onClose() {

    }
    myWindow.kendoWindow({
        width: "700px",
        top: "100px",
        title: "Campaña",
        visible: false,
        actions: [
            "Close"
        ],
        close: onClose
    }).data("kendoWindow").center();
});



function EnviarCampania() {
    var date = $("#fechaInicia").val();
    var date2 = $("#fechaFinaliza").val();
    var estatus = $("#Activa").val() == "SI" ? "1" : "0";

    var Campania = {
        Nombre: $("#txtCampania").val(),
        Descripcion: $("#txtDescripcion").val(),
        Estatus: estatus,
        TipoCampaniaId: 1,
        FechaInicia: date,
        FechaFinaliza: date2
    };
    var URL = "api/Campanias";
    var Type = "POST";

    if ($("#txtCampaniaId").val() != "") {
        Campania.CampaniaId = $("#txtCampaniaId").val();
        URL += "/" + Campania.CampaniaId;
        Type = "PUT";
    }

    $.ajax({
        type: Type,
        url: URL,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Campania),
        success: function (data) {
            alert('success');
            var myWindow = $("#window");
            myWindow.data("kendoWindow").close();
            cargarGrid();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });

}


function Editar() {
    var grid = $("#grid").data("kendoGrid");
    var selectedItem = grid.dataItem(grid.select());
    if (selectedItem != null) {


        $("#txtCampaniaId").val(selectedItem.CampaniaId);
        $("#txtCampania").val(selectedItem.Nombre);
        $("#txtDescripcion").val(selectedItem.Descripcion);
        $("#Activa").val(selectedItem.Estatus);

        //$("#fechaInicia").val(selectedItem.FechaInicia);
        //$("#fechaFinaliza").val(selectedItem.FechaFinaliza);

        var element = document.getElementById('fechaInicia');
        element.value = selectedItem.FechaInicia.substring(0, 10);

        var element = document.getElementById('fechaFinaliza');
        element.value = selectedItem.FechaFinaliza.substring(0, 10);

        var myWindow = $("#window");
        myWindow.data("kendoWindow").open();
    }
    else {
        alert('Seleccione un Registro');
    }
}

function Agregar() {
    limpiar();
    var myWindow = $("#window");
    myWindow.data("kendoWindow").open();
}
function limpiar() {
    $("#txtCampaniaId").val("");
    $("#txtCampania").val("");
    $("#txtDescripcion").val("");
    $("#Activa").val("");

    $("#fechaInicia").val("");
    $("#fechaFinaliza").val("");
}

function viewIndicador() {
    var grid = $("#grid").data("kendoGrid");
    var selectedItem = grid.dataItem(grid.select());
    if (selectedItem != null) {
        window.location.href = "Campania/Indicador?CampaniaId=" + selectedItem.CampaniaId;

        //$.ajax({
        //    type: "POST",
        //    url: "/Campania/Indicador?CampaniaId=" + selectedItem.CampaniaId,
        //    dataType: "json",
        //    async: false,
        //    contentType: "application/json; charset=utf-8",
        //    data: null,
        //    success: function (data) { }
        //});
    }
}

function cargarGrid() {
    $.ajax({
        type: "GET",
        url: "api/Campanias",
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: null,
        success: function (data) {


            for (var index in data) {
                var attr = data[index];
                if (attr.Estatus == "1") {
                    data[index].Estatus = "SI";
                } else {
                    data[index].Estatus = "NO";
                }
            }

            $("#grid").kendoGrid({
                dataSource: data,
                pageable: true,
                height: 550,
                //dataBound: onDataBound,
                toolbar: kendo.template($("#template").html()),
                selectable: true,
                columns: [{
                    field: "Nombre",
                    title: "Nombre Campaña",
                    width: 240
                }, {
                    field: "Descripcion",
                    title: "Descripcion Campaña",
                    width: 240
                }, {
                    field: "Estatus",
                    title: "Activa",
                    width: 80
                }, {
                    field: "FechaInicia",
                    title: "Fecha Inicia",
                    width: 150
                },
                {
                    field: "FechaFinaliza",
                    title: "Fecha Finaliza",
                    width: 150
                }],
                editable: false
            });


        },
        error: function (xhr, ajaxOptions, thrownError) {
            //alert(xhr.status);
            //alert(thrownError);
            location.reload();
        }
    });
}
