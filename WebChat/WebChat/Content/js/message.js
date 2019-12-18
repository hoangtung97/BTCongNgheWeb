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




//send and inbox
$(document).ready(function () {
    var url = "ws://" + window.location.hostname + ":" + location.port
    var endpoint = "/api/APIWS"
    var services = new WebSocket(url + endpoint);
    var userID = parseInt(getCookie("userID"));
    var username = getCookie("displayName");
    var roomID;

    //get room clicked
    $(".roomtab").click(function () {
        roomID = this.id;
        sendbutton = "SendButton" + roomID;
    });

    //press send button message
    $(".SendButton").click(function () {
        if (!services.OPEN) {
            services.close();
            services = new WebSocket(url);
        }
        if ($("#" + roomID + "InputMessage").val() != "") {
            sendingmessage = $("#" + roomID + "InputMessage").val();
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

    //function append sent mess
    function AppendMyMess(message, roomid) {
        var addli = document.createElement("li");
        var adddiv = document.createElement("div");
        adddiv.classList.add("Out");
        adddiv.innerHTML = '<div class="contentOut"><div class="message"><div class="bubbleOut"><p class="pOut">' + message + '</p></div></div></div>';
        addli.appendChild(adddiv);
        $("#" + roomID + "InputMessage").text("");
        $(addli).appendTo("#" + roomid + "message-container")
    }

    //function append inbox mess
    function AppendOtherMess(name, message, roomid) {
        var addli = document.createElement("li");
        var adddiv = document.createElement("div");
        adddiv.classList.add("In");
        adddiv.innerHTML = '<span>' + name + '</span><div class="contentIn"><div class="message"><div class="bubbleIn"><p class ="pIn">' + message + '</p></div></div></div>';
        addli.appendChild(adddiv);
        $(addli).appendTo("#" + roomid + "message-container");
    }

    //show sent and inbox message
    services.onmessage = function (event) {
            var obj = JSON.parse(event.data);
            var cookieid = getCookie("userID");
            if (obj.action == "RECEIVE_MESS") {
                if (obj.id == cookieid) {
                    AppendMyMess(obj.message, obj.id_room);
                }
                else {
                    AppendOtherMess(obj.display_name, obj.message, obj.id_room);
                }
            }       
    }

    //get all room id
    var i = 0;
    var roomids = [];
    $(".roomtab").each(function () {
        roomids[i++] = $(this).attr("id"); //this.id
    });
    var limit = roomids.length;

    function DisplayMess(counter, limit) {
        //alert(counter);
        if (counter < limit)
            $.ajax({
                type: "GET",
                url: "/Main/GetConversations",
                data: { room: roomids[counter] },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var dataNumber = Object.keys(data).length;
                    data.sort((a, b) => (a.Time > b.Time) ? 1 : -1)
                    for (var index1 = 0; index1 < dataNumber; index1++) {
                       if (data[index1].UserID == userID) {
                            AppendMyMess(data[index1].Content, roomids[counter]);
                       }
                       else {
                            AppendOtherMess(data[index1].UserDisplayName, data[index1].Content, roomids[counter]);
                       }

                    }
                    counter++;
                    DisplayMess(counter, limit);
                },
                error: function (data) {
                    alert('error');
                }
            });
    }
    DisplayMess(0, limit);
});
