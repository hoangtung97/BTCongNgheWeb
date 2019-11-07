function ShowTypedMessage() {
    var message = document.getElementById("InputMessage").value;
    if (message != "") {
        var addli = document.createElement("li");
        var adddiv = document.createElement("div");
        adddiv.classList.add("Out");
        adddiv.innerHTML = '<div class="contentOut"><div class="message"><div class="bubbleOut"><p class="pOut">' + message + '</p></div></div></div>';
        addli.appendChild(adddiv);
        document.getElementById("message-container").appendChild(addli);
        document.getElementById("InputMessage").value = "";
    }   
}

function ShowInboxMessage(message, name) {
    var addli = document.createElement("li");
    var adddiv = document.createElement("div");
    adddiv.classList.add("In");
    adddiv.innerHTML = '<span>' + name + '</span><div class="contentIn"><div class="message"><div class="bubbleIn"><p class ="pIn">' + message + '</p></div></div></div>';
    addli.appendChild(adddiv);
    document.getElementById("message-container").appendChild(addli);
}