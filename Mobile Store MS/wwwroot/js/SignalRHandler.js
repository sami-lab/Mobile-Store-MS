class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}


//function sendMessage() {
//    const text = document.getElementById('Text').value
//    if (text.trim() === "") return;
//    var currentdate = new Date();
//    var username = document.getElementById("UserName").value;
//    const when =
//        (currentdate.getMonth() + 1) + "/"
//        + currentdate.getDate() + "/"
//        + currentdate.getFullYear() + " "
//        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
//    let message = new Message(username, text, when);
//    addMessageToChat(message);
//    sendMessageToHub(message);
//}
document.querySelector("#submitbutton").addEventListener("click", function (event) {
//function addchat(event) {
    console.log(event);
    event.preventDefault();
    const text = document.getElementById('Text').value
    if (text.trim() === "") return;
    var currentdate = new Date();
    var username = document.getElementById("UserName").value;
    const when =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
    let message = new Message(username, text, when);
    sendMessageToHub(message);     
});
//function addMessageToChat(message) {
//    var currentdate = new Date();
//    const d =
//        (currentdate.getMonth() + 1) + "/"
//        + currentdate.getDate() + "/"
//        + currentdate.getFullYear() + " "
//        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
//    var image = document.getElementById('userImg').value;
//    var msg = message.text.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    var encodedMsg = ` <div class="d-flex justify-content-start mb-4">
//                                                    <div class="img_cont_msg">
//                                                      <img src="${image}" class="rounded-circle user_img_msg">
//                                                    </div>
//                                                    <div class="msg_cotainer">
//                                                       ${msg}
//                                                        <span class="msg_time">${message.when}</span>
//                                                    </div>
//                                               </div>`;
//    var li = document.createElement("div");
//    li.textContent = encodedMsg;
//    document.getElementById("chat").appendChild(li);
//}
function clearInputField() {   
    document.getElementById('Text').value = "";
}