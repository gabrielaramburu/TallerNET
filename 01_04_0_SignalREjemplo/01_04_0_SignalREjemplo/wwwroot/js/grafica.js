"use strict";
let chart;

//Este js se ejecuta del lado del cliente

//Para que esto funcione, tengo que configurar en Program.cs que existe un hub (server side SiganlR)
//que se llama /ejemploGrafica
var connection = new signalR.HubConnectionBuilder().withUrl("/ejemploGrafica").build();


//recibo mensajes desde el servidor
//este método se ejecuta cuando SignalR recibe un mensaje de tipo "CambioValorGrafica" desde el servidor
connection.on("CambioValorGrafica", function (valor1, valor2, valor3) {
    console.log("Valores obtenidos:" + valor1 + "," + valor2 + "," + valor3);
    //el siguiente codigo simplemente dibuja una grafica
    const ctx = document.getElementById('miGrafica');
    
    if (chart != null) {
        console.log("actualizo grafico");
        chart.data.datasets[0].data = [valor1, valor2, valor3];
        chart.update();

    } else {
        console.log("nuevo grafico");
        chart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['valo1', 'valo2', 'valo3'],
            datasets: [{
                label: '# Gráfica de valores en tiempo real',
                data: [valor1, valor2, valor3],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    
    }
});

//establece la conexión con el servidor
connection.start().then(function () {
    document.getElementById('statusServer').textContent = "Contectado con servidor"; 
}).catch(function (err) {
    document.getElementById('statusServer').textContent = "No conectado"; 
    return console.error(err.toString());
});
