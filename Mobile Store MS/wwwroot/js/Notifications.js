class Notifications {
    constructor(heading, Text, When, Url, read, UserId) {
        this.heading = heading;
        this.Text = Text;
        this.When = When;
        this.Url = Url;
        this.read = read;
        this.UserId = UserId;
    }
}
var notifications = new signalR.HubConnectionBuilder()
    .withUrl('/notifications')
    .build();


notifications.on('RecieveNotification', addNotificationToList);
notifications.start()
    .catch(error => {
        console.error(error.message);
    });


function addNotificationToList(message) {
    console.log("added");
    const ul = document.getElementById('notification_dropdown');
    const date = new Date(message.when);
    var when = Math.floor(Math.abs(new Date() - date) / 36e5);
    let dateString = when + "h ago";
    if (when >= 24) dateString = Math.floor(Math.abs(when / 24)) + "d ago";
    const li = `<li class="icon m-1 list-unstyled d-flex bg_dark" style="border-bottom:1px solid rgba(0,0,0,.1);  padding:1px 0;">
                           <a href="${message.url}">
                               <p class="text">  <span class="font-weight-bolder">${message.heading} </span> ${message.text} </br> <span class="not_time">${dateString}</span ></p>
                            </a>
                         </li >`;
    ul.innerHTML += li;

 
    var noti = document.getElementById('NotificationsCount')
    var count = parseInt(noti.innerText);
    console.log(count);
    noti.innerText = count + 1;
 
}
//function sendNotifications() {
//    const username = document.getElementById('UserName').value;
//    let text = messagesQueue.shift() || "";
//    if (text.trim() === "") return;

//    let currentdate = new Date();
//    let when =
//        (currentdate.getMonth() + 1) + "/"
//        + currentdate.getDate() + "/"
//        + currentdate.getFullYear() + " "
//        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
//    let message = new Message(username, text, when);
//    sendMessageToHub(message);
//}