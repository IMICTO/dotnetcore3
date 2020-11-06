"use strict";
let currentUser = "";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var msgSpan = document.createElement("span");
    msgSpan.classList.add("text-dark");
    msgSpan.textContent = msg;


    var userSpan = document.createElement("span");
    userSpan.textContent = user;
    userSpan.classList.add("font-weight-bold");


    var colonSpan = document.createElement("span");
    colonSpan.textContent = " : ";
    userSpan.classList.add("font-weight-bold");

    if (user === currentUser) {
        userSpan.classList.add("text-primary");
        colonSpan.classList.add("text-primary");
    }
    else {
        userSpan.classList.add("text-success");
        colonSpan.classList.add("text-success");
    }
    var li = document.createElement("li");


    li.appendChild(userSpan);
    li.appendChild(colonSpan);
    li.appendChild(msgSpan);
    li.classList.add("list-group-item");

    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    document.getElementById("messageInput").value = "";

    connection.invoke("SendMessage", currentUser, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


document.getElementById("startButton").addEventListener("click", function (event) {
    currentUser = document.getElementById("nameInput").value;
    document.getElementById("nameInput").value = "";
    document.getElementById("EnterchatRoom").style.display = "none";
    document.getElementById("chatRoom").style.display = "block";
    
    connection.invoke("StartMessage", currentUser).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("JoinedRoom", function (user) {
    var msg = "کاربر '"+ user +"' به گروه پیوست";
    var msgSpan = document.createElement("span");
    msgSpan.classList.add("text-muted");
    msgSpan.textContent = msg;

    var li = document.createElement("li");
    li.appendChild(msgSpan);
    li.classList.add("list-group-item");
    document.getElementById("messagesList").appendChild(li);
});


connection.on("PrivacyViewed", function () {
    alert("یه نفر اومد تو قسمت Privacy");
});