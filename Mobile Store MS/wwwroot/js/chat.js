
var connection = new signalR.HubConnectionBuilder().withUrl("/messages").build();

//Disable send button until connection is established
//document.getElementById("sendButton").setAttribute("sendButton", true);
//document.getElementById("form button").setAttribute("disabled", true);
connection.on("ReceiveMessage", function (message) {
    console.log(message);
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    if (msg.trim() == null) return;
    var currentdate = new Date();
    const d =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
    var image = document.getElementById('userImg').value;
    var encodedMsg = ` <div class="d-flex justify-content-start mb-4">
                                                    <div class="img_cont_msg">
                                                      <img src="${image}" class="rounded-circle user_img_msg">
                                                    </div>
                                                    <div class="msg_cotainer">
                                                       ${msg}
                                                        <span class="msg_time">${d}</span>
                                                    </div>
                                               </div>`;
    var li = document.createElement("div");
    li.textContent = encodedMsg;
    document.getElementById("chat").appendChild(li);
});

connection.start().then(function () {
    //document.getElementById("form button").setAttribute("disabled", true);
}).catch(function (err) {
    return console.error(err.toString());
    });

function sendMessageToHub(message) {  
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
}

//function sendMessageToHub(user, message) {
//    var user = document.getElementById("UserName").value;
//    var message = document.getElementById("Text").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//}
