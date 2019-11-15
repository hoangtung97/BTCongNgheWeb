var services;

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
    var roomID = 1;
    var username = getCookie("displayName");
    $("#SendButton").click(function () {
        if (!services.OPEN) {
            services.close();
            services = new WebSocket(url);
        }

        if ($("#InputMessage").val() != "") {
            var sendingmessage = $("#InputMessage").val();
            var nametodisplay = username;
         
            services.send(JSON.stringify({
                action: 'SEND_MESS',
                id_room: roomID,
                display_name: nametodisplay,
                message: sendingmessage,
                id: userID
            }))
            alert(sendingmessage);
        }
    

    });

    services.onopen = function () {
        services.send(
            JSON.stringify({
                action: 'ADD_U',
                id: userID
        }));
    }

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
                    document.getElementById("message-container").appendChild(addli);
                    document.getElementById("InputMessage").value = "";
                }
                else {
                    var addli = document.createElement("li");
                    var adddiv = document.createElement("div");
                    adddiv.classList.add("In");
                    adddiv.innerHTML = '<span>' + obj.display_name + '</span><div class="contentIn"><div class="message"><div class="bubbleIn"><p class ="pIn">' + obj.message + '</p></div></div></div>';
                    addli.appendChild(adddiv);
                    document.getElementById("message-container").appendChild(addli);
                }
            }
        
       
    }

});

