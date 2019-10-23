var url = "ws://" + window.location.hostname + ":" + location.port
var endpoint = "/api/APIWS"
var ws = new WebSocket(url + endpoint);
ws.onopen = () => {
    alert("OK");
}