$(document).ready(function () {

    //createChart();
    var refreshIntervalId = setInterval('createChart();', 6000);
});

//$(document).bind("kendo:skinChange", createChart);

function createChart() {

    var CampaniaDetalle = null;
    var contador = 0;
    var campaniaId = $("#txtCampaniaId").val();
    $.ajax({
        type: "GET",
        url: "api/CampaniaDetalles/" + $("#txtCampaniaId").val(),
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: null,
        success: function (data) {

            CampaniaDetalle = data;


        },
        error: function (xhr, ajaxOptions, thrownError) {
            location.reload();
        }
    });

    for (var index in CampaniaDetalle) {
        var item = CampaniaDetalle[index];
        $("#txtNombreCampania").text(item.Campania.Nombre);
        var CharId = "#chart" + contador;
        var URL = "api/RespuestaCampanias/" + campaniaId + "/" + item.PreguntaId;
        $.ajax({
            type: "GET",
            url: URL,
            dataType: "json",
            async: false,
            contentType: "application/json; charset=utf-8",
            data: null,
            success: function (dataSource) {

                $(CharId).kendoChart({
                    title: {
                        position: "bottom",
                        text: dataSource.Nombre
                    },
                    legend: {
                        visible: false
                    },
                    chartArea: {
                        background: "",
                        width: 600,
                        height: 400
                    },
                    seriesColors: ["#3f51b5", "#f65858", "#000000", "Red", "#b11dad"],
                    seriesDefaults: {
                        labels: {
                            visible: true,
                            background: "transparent",
                            template: "#= category #: \n #= value#%"
                        }
                    },
                    dataSource: {
                        data: dataSource.DataSource
                    },
                    series: [{
                        startAngle: 90,
                        type: "pie",
                        field: "Porcentaje",
                        categoryField: "Nombre",
                        explodeField: "explode"
                    }],
                    tooltip: {
                        visible: true,
                        format: "{0}%"
                    }
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                location.reload();
            }
        });

        contador++;
    }
}