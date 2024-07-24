const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/football")
    .build();
document.getElementById("sendBtn").addEventListener("click", function () {
    let formData = {
        id: document.querySelector("input[name='Id']").value,
        firstName: document.querySelector("input[name='FirstName']").value,
        lastName: document.querySelector("input[name='LastName']").value,
        gender: document.querySelector("input[name='Gender']:checked").value,
        birthday: document.querySelector("input[name='Birthday']").value,
        teamName: document.querySelector("input[name='TeamName']").value,
        country: document.querySelector("select[name='Country']").value
    };

    hubConnection.invoke("Sender", formData)
        .catch(function (err) {
            return console.error(err.toString());
        });
});

hubConnection.start()
    .then(function () {
        document.getElementById("sendBtn").disabled = false;
    })
    .catch(function (err) {
        return console.error(err.toString());
    });