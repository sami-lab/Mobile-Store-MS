class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}
const messagesQueue = [];

function clearInputField() {
    const text = document.getElementById('Text');
    messagesQueue.push(text.value);
    text.value = "";
}
//For Bulding Data
function sendMessage() {
    const username = document.getElementById('UserName').value;
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let currentdate = new Date();
    let when =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
    let message = new Message(username, text, when);
    sendMessageToHub(message);
}

function addMessageToChat(user, sender, message) {

    //To update Message Count
    if (!window.location.href.includes("CreateMessages")) {
        const messages = $('#messagesCount');
        var CountEmail = messages.attr("data-Email");
        if (CountEmail == user) {
            $('#messagesCount').text(parseInt(messages.text()) + 1);
        }

    }

    if (window.location.href.includes("CreateMessages")) {
        $('#userList li').each(function (index) {
            var Email = $(this).attr('data-Email');
            if (Email == sender) {
                var sp = $(this).find('.user_info span.notification');
                var usercounts = sp.text();
                sp.text(parseInt(usercounts) + 1);
            }

        });
        // var childrenCount = document.getElementById("chat").childNodes.length;
        const username = document.getElementById('CurrentUser').value;
        var messageUser = document.getElementById("UserName").value;

        if (user == messageUser || user == username && messageUser == sender) {

            var childrenCount = parseInt($('.user_info p span.count').text()) + 1;
            let isCurrentUserMessage = user === username;
            var date = new Date(message.when);
            const d =
                (date.getMonth() + 1) + "/"
                + date.getDate() + "/"
                + date.getFullYear() + " "
                + date.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })


            let image = isCurrentUserMessage ? document.querySelector('#chatWith img').getAttribute('src') : document.getElementById('userImg').value;
            let className = isCurrentUserMessage ? "justify-content-end" : "justify-content-start";
            var msg = message.text.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
            let imagediv = null;
            if (isCurrentUserMessage) {
                imagediv = `<div class="msg_cotainer text-break">
                                                       ${msg}
                                                        <span class="msg_time text-nowrap">${d}</span>
                                                    </div>
                                                    <div class="img_cont_msg ml-1">
                                                      <img src="${image}" class="rounded-circle user_img_msg">
                                                    </div>`;
            }
            else {
                imagediv = `<div class="img_cont_msg mr-1">
                                                      <img src="${image}" class="rounded-circle user_img_msg">
                                                    </div>
                                                     <div class="msg_cotainer text-break">
                                                       ${msg}
                                                        <span class="msg_time text-nowrap">${d}</span>
                                                    </div>
                                                    `
            }
            var encodedMsg = ` <div class="d-flex ${className} mb-4">
                                                         ${imagediv}                                             
                                               </div>`;
            var li = document.createElement("div");
            li.innerHTML = encodedMsg;
            document.getElementById("chat").appendChild(li);
            $('.user_info p span.count').text(childrenCount >= 100 ? '100+' : childrenCount);
            var childrens = document.getElementById("chat").childNodes.length;
            document.getElementById("chat").childNodes[childrens - 1].scrollIntoView();
        }

    }
}
