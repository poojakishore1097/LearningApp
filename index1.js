function getData() {
    alert("Calling getData");
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            // Typical action to be performed when the document is ready:
            // document.getElementById("demo").innerHTML = xhttp.responseText;
            alert(xhttp.responseText);
            console.log(xhttp.responseText);

            // Display in array
            
        }
    };
    xhttp.open("GET", "https://localhost:5001/api/user", true);
    xhttp.send();
}
function postData() {
    var data = {
        "id": "id",
        "name": "name",
        "emailId": "emailId"}
      
    alert(xhttp.responseText);
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            // Typical action to be performed when the document is ready:
            // document.getElementById("demo").innerHTML = xhttp.responseText;
            alert(xhttp.responseText);
            console.log(xhttp.responseText);

            // Display in array
            
        }
    };
    xhttp.open("POST", "https://localhost:5001/api/user", true);
    xhttp.send(JSON.stringify(data));
}