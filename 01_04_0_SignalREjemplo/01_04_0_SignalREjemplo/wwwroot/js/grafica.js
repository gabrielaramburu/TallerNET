"use strict";
let chart;

//Este js se ejecuta del lado del cliente

//Para que esto funcione, tengo que configurar en Program.cs que existe un hub (server side SiganlR)
//que se llama /ejemploGrafica

//observar que no usol la url completa, sino que solo uso la parte final del path,
//esto es porque el hub se encuentra en el mismo dominio que la página web y el navegador completa la url
//antes de enviar el pedido. Tener en cuenta que estamos usando una apicación (la librería de signalR)
//de capa 7 del modelo OSI. Juegan las mismas reglas que determina la comunicación en RED
var connection = new signalR.HubConnectionBuilder().withUrl("/ejemploGrafica").build();


//recibo mensajes desde el servidor
//este método se ejecuta cuando SignalR recibe un mensaje de tipo "CambioValorGrafica" desde el servidor

//para ser más precisos el método connection.on se ejecuta al momento que el motor de JS evalua el archivo js, 
//sin embargo, si se observa bien, dentro de este método se declara y define una función anónima 
//que se ejecutará cada vez que el servidor envíe un mensaje de tipo "CambioValorGrafica" al cliente
connection.on("CambioValorGrafica", function (valor1, valor2, valor3) {


    //el servidor me envía esto tres valores, que son los que se van a graficar
    console.log("Valores obtenidos:" + valor1 + "," + valor2 + "," + valor3);
    //a partir de aquí es código del js que se usa para graficar
    //simplemente dibuja una grafica (esto se hace con la librería Chart.js y consultando su documentación))
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
//se ejecuta cuando el motor de JS evalua el archivo js, y se ejecuta una sola vez
connection.start().then(function () {
    document.getElementById('statusServer').textContent = "Contectado con servidor"; 
}).catch(function (err) {
    document.getElementById('statusServer').textContent = "No conectado"; 
    return console.error(err.toString());
});
