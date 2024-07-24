const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/football")
    .build();

hubConnection.start()
    .catch(function (err) {
        return console.error(err.toString());
    });

//Добавление
hubConnection.on("Receive", function (footballer) {
    footballer.birthday = footballer.birthday.split('-').reverse().join('.')
    let val = Object.values(footballer);
    let tr = document.createElement("tr");
    tr.id = footballer.id
        for (let index = 1; index < val.length; ++index) {
        let td = document.createElement("td");
        td.textContent = val[index];
        tr.appendChild(td);
    }
    let td_button = document.createElement("td");
    let a_button = document.createElement("a");
    a_button.className = "btn btn-primary";
    a_button.href = `/footballers/edit/${footballer.id}`;
    a_button.textContent = "Править";
    td_button.appendChild(a_button);
    tr.appendChild(td_button);
    document.getElementById("tbody-of-footballers").appendChild(tr);
});

//Редактирование
hubConnection.on("ReceiveEdit", function (footballer) {
    footballer.birthday = footballer.birthday.split('-').reverse().join('.')
    let val = Object.values(footballer);
    let tr = document.createElement("tr");
    tr.id = footballer.id
    for (let index = 1; index < val.length; ++index) {
        let td = document.createElement("td");
        td.textContent = val[index];
        tr.appendChild(td);
    }
    let td_button = document.createElement("td");
    let a_button = document.createElement("a");
    a_button.className = "btn btn-primary";
    a_button.href = `/footballers/edit/${footballer.id}`;
    a_button.textContent = "Править";
    td_button.appendChild(a_button);
    tr.appendChild(td_button);

    document.getElementById(footballer.id).replaceWith(tr);
});

//Удаление
hubConnection.on("ReceiveDelete", function (id) {
    document.getElementById(id).remove();
});

//Обновляет страницу, если переход был через "Назад"
if (performance.navigation.type == 2) {
    location.reload(true);
}
