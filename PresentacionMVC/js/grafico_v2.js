
document.oncontextmenu = function () { return false; }


var chartPrimero = null;
var chartPincipal = null;
var chartSemanal = null;

var widthP = null;
var grosorCol = 0;

var G_1_Principal = true;

var primerOptionInicio = 0;

$(document).ready(function () {

    
    //cargarMesesXanio();
    obtenerTamañoPantalla();
    obtenerInfectados();

    mostrarPorcentajeMortalidad();
    mostrarPorcentajeInfectados();

    chartPrincipal();
    obtenerInfectadosSemanal();

    $('#btnInfectados').click(function () {
        G_1_Principal = true;
        obtenerInfectados();
    });
    $('#btnInfectadosXdia').click(function () {
        G_1_Principal = false;
        obtenerInfectadosXdia();
    });

    $('#cboAnios').change(function () {
        cargarMesesXanio();
        obtenerInfectadosSemanal();
        if (G_1_Principal) {
            obtenerInfectados();
        } else {
            obtenerInfectadosXdia();
        }
    });
    $('#cboMeses').change(function () {
        if (G_1_Principal) {
            obtenerInfectados();
        } else {
            obtenerInfectadosXdia();
        }
    });

    $(window).on("resize", function (event) {
        //alert("Este dispositivo está en modo " + event.orientation);
        myFunction('resize');
    });
    $(window).on("orientationchange", function (event) {
        //alert("Este dispositivo está en modo " + event.orientation);
        myFunction('orientation');
    });
});




function obtenerTamañoPantalla() {
    widthP = screen.width;
    
    if (widthP < 479) grosorCol = 4;
    if (widthP >= 479 && widthP < 508) grosorCol = 4.2;
    if (widthP >= 508 && widthP < 540) grosorCol = 4.5;
    if (widthP >= 540 && widthP < 584) grosorCol = 5;
    if (widthP >= 584 && widthP < 725) grosorCol = 5.5;
    if (widthP >= 725 && widthP < 840) grosorCol = 6;
    if (widthP >= 840 && widthP < 980) grosorCol = 7;
    if (widthP >= 980 && widthP < 1080) grosorCol = 8;
    if (widthP >= 1080 && widthP < 1144) grosorCol = 9;
    if (widthP >= 1144 && widthP < 1600) grosorCol = 10;
    if (widthP >= 1600 && widthP < 1750) grosorCol = 11;
    if (widthP >= 1750 && widthP < 1900) grosorCol = 12;
    if (widthP >= 1900 && widthP < 2330 ) grosorCol = 14;
    if (widthP >= 2330 && widthP < 2560 ) grosorCol = 15;
    if (widthP >= 2560 ) grosorCol = 18;
    //console.log('widthP');
    //console.log(widthP);
    //console.log('Grosor');
    //console.log(grosorCol);

}


function obtenerInfectados() {
    //cargarMesesXanio();
    var numAnio = $('#cboAnios').val();
    //var numMes = $('#cboMeses').val() == null ? primerOptionInicio : $('#cboMeses').val();
    var numMes = $('#cboMeses').val();

    $.ajax({
        type: 'POST',
        url: '/Registros/JsonInfectados?numAnio=' + numAnio + '&numMes=' + numMes,
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            console.log(miJson);

            document.getElementById("G_1").remove();
            document.getElementById("contenedorCanvas").innerHTML += '<canvas id="G_1" class=" chartjs-render-monitor"></canvas>';
            let miCanvas = document.getElementById("G_1");
            let ctx = miCanvas.getContext("2d");
            ctx.fillStyle = "#ffffff";
            ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
            var grafica = new Chart(ctx, {/* Opciones aquí */ });


            chartPrimero = new Chart(ctx, {
                type: "bar",
                data: {

                    labels: miJson[0],
                    datasets: [
                        {
                            label: "Infectados",
                            backgroundColor: "rgb(252,146,4)",
                            data: miJson[1]
                        },
                        {
                            label: "Fallecidos",
                            backgroundColor: "rgb(250,20,20)",
                            data: miJson[2]
                        },
                        {
                            label: "Recuperados",
                            backgroundColor: "rgb(20,150,20)",
                            data: miJson[3]
                        }
                    ]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            spacing: 500,
                            barPercentage: 1,//1
                            categoryPercentage: 1,//1
                            barThickness: grosorCol,//13
                            ticks: {
                                minRotation: 0,
                                autoskip: true,
                                autoSkipPadding: 50,
                                maxTicksLimit: 2000000,
                                beginAtZero: false,
                            },
                            gridLines: {
                                drawOnChartArea: false
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            })

        }
    });
}
function obtenerInfectadosXdia() {
    //cargarMesesXanio();
    var numAnio = $('#cboAnios').val();
    var numMes = $('#cboMeses').val();
    $.ajax({
        type: 'POST',
        url: '/Registros/JsonInfectadosXdia?numAnio=' + numAnio + '&numMes=' + numMes,
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            console.log(miJson);

            document.getElementById("G_1").remove();
            document.getElementById("contenedorCanvas").innerHTML += '<canvas id="G_1" class=" chartjs-render-monitor"></canvas>';

            let miCanvas = document.getElementById("G_1");
            let ctx = miCanvas.getContext("2d");
            ctx.fillStyle = "#ffffff";
            ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
            var grafica = new Chart(ctx, {/* Opciones aquí */ });

            chartPrimero = new Chart(ctx, {
                type: "bar",
                data: {

                    labels: miJson[0],
                    datasets: [
                        {
                            label: "Infectados por Dia",
                            backgroundColor: "rgb(60,40,240)",
                            data: miJson[1]
                        }
                    ]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            ticks: {
                                autoSkip: true,
                                maxTicksLimit: 20000
                            },
                            gridLines: {
                                drawOnChartArea: false
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            })
        }
    });
}
function chartPrincipal() {
    $.ajax({
        type: 'POST',
        url: '/Registros/JsonChartPrincipal',
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            console.log(miJson);

            document.getElementById("G_2").remove();
            document.getElementById("contenedorCanvas2").innerHTML += '<canvas id="G_2" class=" chartjs-render-monitor"></canvas>';
            let miCanvas = document.getElementById("G_2");
            let ctx = miCanvas.getContext("2d");
            ctx.fillStyle = "#ffffff";
            ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
            var grafica = new Chart(ctx, {/* Opciones aquí */ });


            chartPincipal = new Chart(ctx, {
                type: "line",
                data: {

                    labels: miJson[0],
                    datasets: [
                        {
                            label: "Infectados",
                            backgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                            borderCapStyle: 'butt',
                            borderColor: 'rgba(252,146,4, 0.8)',
                            pointBackgroundColor: 'rgb(252,146,4)',
                            data: miJson[1]
                        },
                        {
                            label: "Fallecidos",
                            backgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                            borderCapStyle: 'butt',
                            borderColor: 'rgba(250,20,20, 0.8)',
                            pointBackgroundColor: 'rgb(250,20,20)',
                            data: miJson[2]
                        },
                        {
                            label: "Recuperados",
                            backgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                            borderCapStyle: 'butt',
                            borderColor: 'rgba(20,150,20, 0.8)',
                            pointBackgroundColor: 'rgb(20,150,20)',
                            data: miJson[3]
                        }
                        //,
                        //{
                        //    label: "Casos Activos",
                        //    backgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                        //    borderCapStyle: 'butt',
                        //    borderColor: 'rgba(20,150,200, 0.8)',
                        //    pointBackgroundColor: 'rgb(20,150,200)',
                        //    data: miJson[4]
                        //}
                    ]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            spacing: 0,
                            barPercentage: 1,
                            categoryPercentage: 1,
                            barThickness: 1,
                            ticks: {
                                minRotation: 0,
                                autoskip: true,
                                autoSkipPadding: 0,
                                maxTicksLimit: 2000000,
                                beginAtZero: false,
                                display: false // Ocultar eje X 
                            },
                            gridLines: {
                                drawOnChartArea: false
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            })

        }
    });
}



function obtenerInfectadosSemanal() {
    var numAnio = $('#cboAnios').val();
    $.ajax({
        type: 'POST',
        url: '/Registros/JsonInfectadosSemanal?numAnio=' + numAnio,
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            console.log(miJson);

            CambiarTituloSemana(numAnio);

            document.getElementById("G_3").remove();
            document.getElementById("contenedorCanvas3").innerHTML += '<canvas id="G_3" class=" chartjs-render-monitor"></canvas>';
            let miCanvas = document.getElementById("G_3");
            let ctx = miCanvas.getContext("2d");
            ctx.fillStyle = "#ffffff";
            ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
            var grafica = new Chart(ctx, {/* Opciones aquí */ });


            chartSemanal = new Chart(ctx, {
                type: "line",
                data: {

                    labels: miJson[0],
                    datasets: [
                        {
                            label: "Infectados",
                            backgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                            borderCapStyle: 'butt',
                            borderColor: 'rgba(252,146,4, 0.8)',
                            pointBackgroundColor: 'rgb(252,146,4)',
                            data: miJson[1]
                        },
                        {
                            label: "Fallecidos",
                            backgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                            borderCapStyle: 'butt',
                            borderColor: 'rgba(250,20,20, 0.8)',
                            pointBackgroundColor: 'rgb(250,20,20)',
                            data: miJson[2]
                        },
                        {
                            label: "Recuperados",
                            bbackgroundColor: "rgba(255,255,255,0.0)", // fondo blanco
                            borderCapStyle: 'butt',
                            borderColor: 'rgba(20,150,20, 0.8)',
                            pointBackgroundColor: 'rgb(20,150,20)',
                            data: miJson[3]
                        }
                    ]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            spacing: 500,
                            barPercentage: 1,//1
                            categoryPercentage: 1,//1
                            barThickness: grosorCol,//13
                            ticks: {
                                minRotation: 0,
                                autoskip: true,
                                autoSkipPadding: 50,
                                maxTicksLimit: 200000,
                                beginAtZero: false,
                            },
                            gridLines: {
                                drawOnChartArea: false
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            })

        }
    });
}

function mostrarPorcentajeInfectados() {

    $.ajax({
        type: 'POST',
        url: '/Registros/JsonPorcentajeInfectados',
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            document.getElementById("lblPorcentajeInfectados").innerText = "INFECTADOS\n" + miJson + " %";
        }
    })
}
function mostrarPorcentajeMortalidad() {
    $.ajax({
        type: 'POST',
        url: '/Registros/JsonPorcentajeMortalidad',
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            document.getElementById("lblPorcentajeMortalidad").innerText = "MORTALIDAD\n" + miJson + " %";
        }
    })
}

function cargarMesesXanio() {
    var anio = $('#cboAnios').val();
    var cadena = '{"anio":' + anio + '}';
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Registros/JsonMesesXanio',
        data: cadena,
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (miJson) {
            //$('#cboMeses').val('');
            var contador = 0;
            $('#cboMeses').empty();
            for (let x = 0; x < miJson.length; x++) {
                var arrayOption = miJson[x];
                if (contador == 0) primerOptionInicio = arrayOption[0];
                contador++;
                $('#cboMeses').append(
                    '<option value="' + arrayOption[0] + '">' + arrayOption[1] + '</option>'
                );
            }
            
        }
    })
}

function CambiarTituloSemana(anio) {
    document.getElementById('idTituloSemana').innerHTML = '<p class="subtitulos">Gráfico por Semana | Año: ' + anio +'</p>'
}



function myFunction(value) {
    if (value == 'resize') {
       // do something
    } else if (value == 'orientation') {
        location.reload(true);
    }
}
// Para tema oscuro, mirar tambien en boostrap
//if (window.matchMedia('(prefers-color-scheme)').media === 'not all') {
//    console.log('El navegador no soporta este modo');
//}