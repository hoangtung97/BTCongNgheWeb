var services;
var currRoom;



function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

$(document).ready(function () {

    var url = "ws://" + window.location.hostname + ":" + location.port
    var endpoint = "/api/APIWS"
    var services = new WebSocket(url + endpoint);
    var userID = parseInt(getCookie("userID"));
    var username = getCookie("displayName");
    var roomID;
    var sendbutton
    //get room clicked
    $(".roomtab").click(function () {
        roomID = this.id;
        alert(roomID); 
        sendbutton = "SendButton" + roomID;
        alert(sendbutton);

    });
    //press send button message


    $(".SendButton").click(function () {
        if (!services.OPEN) {
            services.close();
            services = new WebSocket(url);
        }
        alert("buttonclicked");
        if ($("#" + roomID + "InputMessage").val() != "") {
            sendingmessage = $("#" + roomID + "InputMessage").val();
            alert(sendingmessage);
            nametodisplay = username;
            services.send(JSON.stringify({
                action: 'SEND_MESS',
                id_room: roomID,
                display_name: nametodisplay,
                message: sendingmessage,
                id: userID
            }))
        }
    });

    services.onopen = function () {
        services.send(
            JSON.stringify({
                action: 'ADD_U',
                id: userID
        }));
    }
    //show sent and inbox message

    services.onmessage = function (event) {
            var obj = JSON.parse(event.data);
            var cookieid = getCookie("userID");
            if (obj.action == "RECEIVE_MESS") {
            if (obj.id == cookieid) {
                   
                    var addli = document.createElement("li");
                    var adddiv = document.createElement("div");
                    adddiv.classList.add("Out");
                    adddiv.innerHTML = '<div class="contentOut"><div class="message"><div class="bubbleOut"><p class="pOut">' + obj.message + '</p></div></div></div>';
                    addli.appendChild(adddiv);
                    $("#" + roomID + "InputMessage").val() != "";
                    $(addli).appendTo("#" + obj.id_room + "message-container")
                }
                else {
                    var addli = document.createElement("li");
                    var adddiv = document.createElement("div");
                    adddiv.classList.add("In");
                    adddiv.innerHTML = '<span>' + obj.display_name + '</span><div class="contentIn"><div class="message"><div class="bubbleIn"><p class ="pIn">' + obj.message + '</p></div></div></div>';
                    addli.appendChild(adddiv);
                    $(addli).appendTo("#" + obj.id_room + "message-container");
                }
            }
        
       
    }
  

});

