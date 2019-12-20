$(document).ready(function () {
    //click group button
    $("#GroupA").click();



    //kick user
    $(".kickbutton").click(function () {
        var buttonid = this.id;
        var ID = buttonid.split("-");
        var UserToDelete = ID[0];
        var RoomJoined = ID[1];
        var UserId = parseInt(getCookie("userID"));
        $.ajax({
            type: "GET",
            url: "/Main/DeleteUserInRoom",
            data: { userid: UserId, kickuserid: UserToDelete, roomid: RoomJoined },
            success: function () {
                $("#" + "user" + UserToDelete + "inroom" + RoomJoined).remove();
            },
            error: function () {
                alert('error deleting user from room');
            }
        });
    });

    //leave room
    $(".leavebutton").click(function () {
        var buttonid = this.id;
        var ID = buttonid.split("ExitRoom");
        //alert(ID[0]);
        var User = getCookie("userID");
        //alert(User);

        $.ajax({
            type: "GET",
            url: "/Main/ExitRoom",
            data: { userid: User, roomid: ID[0] },
            success: function () {
                //xoa tab room
                $("#" + ID[0] + "RoomList").remove();
                $("#" + "chat" + ID[0]).remove();
            },
            error: function () {
                alert('error leaving this room');
            }
        });

    });

    //prevent reload page after press enter
    $("#SearchText").on('keydown', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            $(".SearchButton").click();
        }
    });
    //searchroom
    $(".SearchButton").click(function () {
        var roomname = $("#SearchText").val();
        if (roomname != "") {
            var myClasses = document.querySelectorAll('.RoomList'),
                i = 0,
                l = myClasses.length;
            for (i = 0; i < l; i++) {
                var name = myClasses[i].getAttribute("name");
                if (name.includes(roomname)) {
                    myClasses[i].setAttribute("style", "display:list-item");
                    var roomlistid = myClasses[i].getAttribute("id");
                    var roomid = roomlistid.split("RoomList");
                    $("#" + roomid[0]).click();
                }
                else {
                    myClasses[i].setAttribute("style", "display:none");
                }
            }       
        }
        else {
            var myClasses = document.querySelectorAll('.RoomList'),
                i = 0,
                l = myClasses.length;
            for (i = 0; i < l; i++) {
                var name = myClasses[i].getAttribute("name");
                myClasses[i].setAttribute("style", "display:list-item");
            }
        }
    });


});