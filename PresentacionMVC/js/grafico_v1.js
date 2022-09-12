////<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
////    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
////    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
////<script src="~/js/Chart.min.js"></script>
////    <script src="~/js/Chart.js"></script>



//    $(document).ready(function () {
//        obtenerInfectados();
//    });
//    $(document).ready(function () {
//        mostrarPorcentajeInfectados();
//    });
//    $(document).ready(function () {
//        mostrarPorcentajeMortalidad();
//    });
//    function mostrarPorcentajeInfectados() {
//        //fetch("@Url.Content("~/Registros/JsonPorcentajeInfectados")")
//        fetch("~/Registros/JsonPorcentajeInfectados")
//            .then(function (result) {
//                return result.json();
//            })
//            .then(function (miJson) {
//                //console.log("JsonPorcentaje:");
//                //console.log(miJson);
//                document.getElementById("lblPorcentajeInfectados").innerText = "INFECTADOS\n" + miJson + " %";
//            })
//        //document.getElementById("lblPorcentajeInfectados").innerText = "HOLA :D";
//    };

//    function mostrarPorcentajeMortalidad() {
//        fetch("~/Registros/JsonPorcentajeMortalidad")
//            .then(function (result) {
//                return result.json();
//            })
//            .then(function (miJson) {
//                //console.log("JsonPorcentaje:");
//                //console.log(miJson);
//                document.getElementById("lblPorcentajeMortalidad").innerText = "MORTALIDAD\n" + miJson + " %";
//            })
//        //document.getElementById("lblPorcentajeInfectados").innerText = "HOLA :D";
//    };


//    //$(document).ready(function () {
//    //    var serviceURL = '/AjaxTest/FirstAjax';
//    //    $.ajax({
//    //    type: "POST",
//    //        url: "~/Registros/JsonPorcentajeInfectados",
//    //        data: param ,
//    //        contentType: "application/json; charset=utf-8",
//    //        dataType: "json",
//    //        success: successFunc,
//    //        error: errorFunc
//    //        //falta asignar valor lbl segun el dato obtenido
//    //        document.getElementById("lblPorcentajeInfectados").
//    //    });
//    //})

//    //let miCanvas = document.getElementById("G_1");
//    //let ctx = miCanvas.getContext("2d");
//    //ctx.fillStyle = "#ffffff";
//    //ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
//    //window.grafica = new Chart(ctx, {/* Opciones aquí */});

//    var chart1 = null;

//    // ==================== INFECTADOS FALLECIDOS RECUPERADOS ===============
//    function obtenerInfectados() {

//        //fetch("@Url.Content("~/Registros/JsonInfectados")")
//        fetch("~/Registros/JsonInfectados")
//            .then(function (resultado) {
//                return resultado.json();
//            })
//            .then(function (miJson) {
//                //console.log(miJson);

//                //let miCanvas = document.getElementById("G_1").getContext("2d");

//                document.getElementById("G_1").remove();
//                document.getElementById("contenedorCanvas").innerHTML += '<canvas id="G_1" class=" chartjs-render-monitor"></canvas>';
//                //document.getElementById("contenedorCanvas").innerHTML('<canvas id="G_1" class=" chartjs-render-monitor"></canvas>');

//                let miCanvas = document.getElementById("G_1");
//                let ctx = miCanvas.getContext("2d");
//                ctx.fillStyle = "#ffffff";
//                ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
//                var grafica = new Chart(ctx, {/* Opciones aquí */ });
//                // bind event handler to clear button


//                chart1 = new Chart(ctx, {
//                    type: "bar",
//                    data: {

//                        labels: miJson[0],
//                        datasets: [
//                            {
//                                label: "Infectados",
//                                backgroundColor: "rgb(252,146,4)",
//                                data: miJson[1]
//                            },
//                            {
//                                label: "Fallecidos",
//                                backgroundColor: "rgb(250,20,20)",
//                                data: miJson[2]
//                            },
//                            {
//                                label: "Recuperados",
//                                backgroundColor: "rgb(20,150,20)",
//                                data: miJson[3]
//                            }
//                        ]
//                    },
//                    options: {
//                        responsive: true,
//                        maintainAspectRatio: false,
//                        scales: {
//                            xAxes: [{
//                                spacing: 500,
//                                barPercentage: 1,
//                                categoryPercentage: 1,
//                                barThickness: 5,
//                                ticks: {
//                                    minRotation: 0,
//                                    autoskip: true,
//                                    autoSkipPadding: 50,
//                                    maxTicksLimit: 200000,
//                                    beginAtZero: false,
//                                },
//                                gridLines: {
//                                    drawOnChartArea: false
//                                }
//                            }],
//                            yAxes: [{
//                                ticks: {
//                                    beginAtZero: true
//                                }
//                            }]
//                        }
//                    }
//                })
//            })
//    }
//    // ==================== INFECTADOS FALLECIDOS RECUPERADOS ===============
//    function obtenerInfectadosXdia() {



//        //fetch("@Url.Content("~/Registros/JsonInfectadosXdia")")
//        fetch("~/Registros/JsonInfectadosXdia")
//            .then(function (resultado) {
//                return resultado.json();
//            })
//            .then(function (miJson) {
//                //console.log(miJson);

//                //let miCanvas = document.getElementById("G_1").getContext("2d");

//                document.getElementById("G_1").remove();
//                document.getElementById("contenedorCanvas").innerHTML += '<canvas id="G_1" class=" chartjs-render-monitor"></canvas>';
//                //document.getElementById("contenedorCanvas").innerHTML('<canvas id="G_1" class=" chartjs-render-monitor"></canvas>');


//                let miCanvas = document.getElementById("G_1");
//                let ctx = miCanvas.getContext("2d");
//                ctx.fillStyle = "#ffffff";
//                ctx.clearRect(miCanvas.width, miCanvas.height, miCanvas.width, miCanvas.height);
//                var grafica = new Chart(ctx, {/* Opciones aquí */ });


//                chart1 = new Chart(ctx, {
//                    type: "bar",
//                    data: {

//                        labels: miJson[0],
//                        datasets: [
//                            {
//                                label: "Infectados por Dia",
//                                backgroundColor: "rgb(60,40,240)",
//                                data: miJson[1]
//                            }
//                        ]
//                    },
//                    options: {
//                        responsive: true,
//                        maintainAspectRatio: false,
//                        scales: {
//                            xAxes: [{
//                                ticks: {
//                                    autoSkip: true,
//                                    maxTicksLimit: 2000
//                                },
//                                gridLines: {
//                                    drawOnChartArea: false
//                                }
//                            }],
//                            yAxes: [{
//                                ticks: {
//                                    beginAtZero: true
//                                }
//                            }]
//                        }
//                    }
//                })
//            })
//    }














//    //Ejemplo (No Modificar)
//    //function Ejemplo() {
//    //    //fetch("@Url.Content("~/Registros/JsonInfectados")")
//    //    fetch("~/Registros/JsonInfectados")
//    //        .then(function (resultado) {
//    //            return resultado.json();
//    //        })
//    //        .then(function (miJson) {
//    //            console.log(miJson);
//    //            datos = miJson;
//    //            let lstInfectados = "";

//    //            for (let i = 0; i < miJson.length; i++) {
//    //                lstInfectados += "<p>" + miJson[i] + "</p>";

//    //            }
//    //            document.getElementById("MiDiv").innerHTML = lstInfectados;
//    //        })
//    //}

