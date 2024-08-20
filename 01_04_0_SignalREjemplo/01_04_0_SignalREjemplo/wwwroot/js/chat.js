"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/miChat").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

//recivo mensajes desde el servidor
connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
   
    li.textContent = `${user} says ${message}`;
});

//establece la conexión con el servidor
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    //envío mensaje al servidor
    //Notese que en el Hub esta implementado el metodo SendMessage
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});