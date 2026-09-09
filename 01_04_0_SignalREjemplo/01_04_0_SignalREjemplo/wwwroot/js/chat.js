"use strict";


//me conetcto con el Hub que se encuentra en el servidor
var connection = new signalR.HubConnectionBuilder().withUrl("/miChat").build();

//por defecto apago el botón de enviar.
document.getElementById("sendButton").disabled = true;

//recivo mensajes desde el servidor
connection.on("ReceiveMessage", function (user, message) {

    // creo el elemento LI antes de añadirlo
    var li = document.createElement("li");

    //es la misma idea que vimos para las gráficas, con la diferencia de que aquí mostramos el mensaje recibido como parámetro
    document.getElementById("messagesList").appendChild(li);
   
    li.textContent = `${user} says ${message}`;
});

//establece la conexión con el servidor
connection.start().then(function () {
    //si establezco la conexión con el servidor, habilito el botón de enviar
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    //envío mensaje al servidor
    //Notese que en el Hub esta implementado el metodo EnviarMesajes
    connection.invoke("EnviarMensaje", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});