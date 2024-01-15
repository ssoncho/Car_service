$.ajax({
    type: "GET",
    url: "https://5c08-178-46-122-56.ngrok-free.app/api/Orders", // URL для обработки данных на сервере
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    headers: { 
      'ngrok-skip-browser-warning': 'true' 
    },
    success: function(response) {
        console.log(response);
        /*response = {
            "orders": [
              {
                "orderId": 123,
                "creationDate": "2023-12-28T09:00:00+05:00",
                "completionDate": "2023-12-29T09:00:00+05:00",
                "status": "planned",
                "totalPrice": 1800,
                "customer": {
                  "name": "Иван",
                  "patronymic": "Иванович",
                  "surname": "Иванов"
                },
                "workers": [
                  {
                    "name": "Сергей",
                    "patronymic": "Сергеевич",
                    "surname": "Сергеев"
                  }
                ]
              }
            ]
          }*/
          response["orders"].forEach(element => {
            function formatDate(inputDateString) {
              let date = new Date(inputDateString);

            // Получаем компоненты даты и времени
              let day = date.getUTCDate();
              let month = date.getUTCMonth() + 1; // Месяцы в JavaScript начинаются с 0, поэтому добавляем 1
              let year = date.getUTCFullYear();
              let hours = date.getUTCHours() + 5;
              if (hours == 24) {
                hours = 0;
                day += 1;
              };
              let minutes = date.getUTCMinutes();

              // Форматируем дату и время в соответствии с требуемым форматом
              return `${(day < 10 ? '0' : '') + day}.${(month < 10 ? '0' : '') + month}.${year} ${(hours < 10 ? '0' : '') + hours}:${(minutes < 10 ? '0' : '') + minutes}`;
            }
            // Выводим отформатированную дату
            let complitionDate = element["completionDate"] !== null ? formatDate(element["completionDate"]) : "...";
            
            let row = `<a class="current-application" href="#" onclick="setOrderIdForItem(` + element["orderId"] + `)"><div class="div-block-3">
                <div class="information-of-application">
                    <div class="order2">Заказ №` + element["orderId"] + `</div>
                    <div class="order-received2">` + formatDate(element["creationDate"]) + `</div>
                    <div class="status-of-order2">` + translateStatus(element["status"]) + `</div>
                    <div class="order-completed2">` + complitionDate + `</div>
                    <div class="cost-of-order2">` + element["totalPrice"] + ` руб.</div>
                    <div class="client2">` + element["customer"]["surname"] + ` ` + element["customer"]["name"][0] + `.` + element["customer"]["patronymic"][0] + `.</div>
                    <div class="responsible2">`;
            let workers = element["workers"];
            if (workers.length >= 2) {
              let worker = workers[0];
              row += worker["surname"] + ' ' + worker["name"][0] + '.' + worker["patronymic"][0] + '. ... ';
            } else {
              element["workers"].forEach(worker => {
                row += worker["surname"] + ' ' + worker["name"][0] + '.' + worker["patronymic"][0] + '.';
            });
            }           
            row += `</div>
                  </div>
            </div></a>` 
            $("#all-applications").append(row);
          });

    },

    error: function(error) {
    console.error("Произошла ошибка при сохранении данных");
    console.log(error);
    }
});

function setOrderIdForItem(orderId){ // извлечение orderId
    localStorage.setItem('currentOrderId', orderId); // сохранение orderId
    window.location.href = 'index.html';
}

$("#allFilterButton").on("click", function() {
  $("#all-applications").empty();
  getOrdersByStatus("");
});

// Фильтрация заказов по статусу "запланирован"
$("#plannedFilterButton").on("click", function() {
  $("#all-applications").empty();
  getOrdersByStatus("planned");
});

// Фильтрация заказов по статусу "поступил"
$("#receivedFilterButton").on("click", function() {
  $("#all-applications").empty();
  getOrdersByStatus("not-viewed");
});

// Фильтрация заказов по статусу "в работе"
$("#inProgressFilterButton").on("click", function() {
  $("#all-applications").empty();
  getOrdersByStatus("in-process");
});

// Фильтрация заказов по статусу "завершен"
$("#completedFilterButton").on("click", function() {
  $("#all-applications").empty();
  getOrdersByStatus("done");
});

//изменение цвета кнопок со статусами по нажатию на них
$(".button").on("click", function() {
  $(".button").css({
    "color": "#BABABA",
    "font-weight": "normal"
  });
  $(this).css({
    "color": "#347BA3",
    "font-weight": "bold"
  });
});
