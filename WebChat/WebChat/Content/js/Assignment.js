$(document).ready(function () {
 
    //get room create form and create room
    $("#createRoomButton").click(function () {
        //alert("button click");
        var name, pass;
        if ($("#groupnameID").val() != "" && $("#grouppassID").val() != "") {
            name = $("#groupnameID").val();
            pass = $("#grouppassID").val();
            alert(name);
            alert(pass);
            //mot cai ham nao do de xoa chu tren form @_@
        }

        $.ajax({
            type: "POST",
            url: "Main/CreateRoom",
            data: { roomname: name, roompass: pass },
            success: function (response) {
                alert("success");
            }
    
        })
    })

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
                alert('He is Out');
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
                alert('You have just left a room');
                //xoa tab room
                $("#" + ID[0] + "RoomList").remove();
                $("#" + "chat" + ID[0]).remove();
            },
            error: function () {
                alert('error leaving this room');
            }
        });

    });

});