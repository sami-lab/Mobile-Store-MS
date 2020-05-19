var connection = new signalR.HubConnectionBuilder()
    .withUrl('/messages')
    .build();


connection.on('ReceiveMessage', addMessageToChat);
connection.start()
    .catch(error => {
        console.error(error.message);
    });

connection.on('UserConnected', function (ids) {
    var listItems = $("#userList li");    
    listItems.each(function (idx, li) {
        var dataId = $(this).attr("data-id");
        if (ids.includes(dataId)) {
            $(this).children().children().find(".img_cont span").addClass('online_icon');
        }       
    });
   
});
connection.on('UserDisconnected', function (id) {
    var listItems = $("#userList li");
    listItems.each(function (idx, li) {
        var dataId = $(this).attr("data-id");
        if (dataId == id) {
            $(this).children().children().find(".img_cont span").removeClass('online_icon');
        }
    });
});
function sendMessageToHub(message) {
    connection.invoke('SendMessage', message);
}