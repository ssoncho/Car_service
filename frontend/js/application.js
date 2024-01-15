window.onload = function() {
    let orderId = localStorage.getItem('currentOrderId');
    if (orderId === null)
        return;

    $.ajax({
        type: "GET",
        url: "https://5c08-178-46-122-56.ngrok-free.app/api/Orders/" + orderId, // URL для обработки данных на сервере
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 
        'ngrok-skip-browser-warning': 'true' 
        },
        success: function(response) {
            
            console.log(response);
            // response = {
            //     "orderId": 123,
            //     "problemDescription": "Проблема с двигателем",
            //     "status": "planned",
            //     "creationDate": "2023-12-25T09:00:00+05:00",
            //     "completionDate": null,
            //     "car": {
            //       "id": 789,
            //       "mileage": 120000,
            //       "brand": "Toyota",
            //       "vin": "1HGCM82633A123456",
            //       "stateNumber": "A123BC789",
            //       "model": "Camry",
            //       "manufactureYear": 2010
            //     },
            //     "customer": {
            //       "id": 654,
            //       "name": "Иван",
            //       "patronymic": "Иванович",
            //       "surname": "Иванов",
            //       "phoneNumber": "+79001234567",
            //       "telegramAlias": "@ivanov",
            //       "vkAlias": "id123456789"
            //     },
            //     "record": {
            //       "id": 6,
            //       "boxId": 3,
            //       "startTime": "2023-12-26T09:00:00+05:00",
            //       "endTime": "2023-12-26T18:00:00+05:00"
            //     },
            //     "workerParticipations": [
            //       {
            //         "id": 135,
            //         "status": "inProcess",
            //         "comment": "Работа в процессе",
            //         "worker": {
            //           "name": "Иван",
            //           "patronymic": "Иванович",
            //           "surname": "Иванов"
            //         },
            //         "servicePosition": {
            //           "id": 135,
            //           "name": "Заменить масло",
            //           "price": 5000
            //         },
            //         "materialPositions": [
            //           {
            //             "id": 579,
            //             "name": "Моторное масло",
            //             "price": 500,
            //             "count": 4,
            //             "clientHas": false
            //           }
            //         ]
            //       }
            //     ],
            //     "productPositions": [
            //       {
            //         "id": 864,
            //         "name": "Дворники",
            //         "price": 2500,
            //         "count": 1
            //       }
            //     ],
            //     "totalPrice": 8000
            //   }


            //let statuss = response["status"];
            //console.log(translateStatus(statuss));
            $("#name").text("Заявка №" + response["orderId"]);
            $("#status").text(translateStatus(response["status"]));
            $("#full-name").text(response["customer"]["surname"] + " " + response["customer"]["name"] + " " + response["customer"]["patronymic"]);
            $("#phoneNumber").text(response["customer"]["phoneNumber"]);
            $("#reason-for-appeal").text(response["problemDescription"]);
            if (response["customer"]["telegramAlias"]) {
                $("#telegram").attr("href", "https://t.me/" + response["customer"]["telegramAlias"]);
            } else {
                $("#telegram").hide();
            }
            if (response["customer"]["vkAlias"]) {
                $("#vk").attr("href", "https://vk.com/" + response["customer"]["vkAlias"]);
            } else {
                $("#vk").hide();
            }
            $("#carModel").text(response["car"]["brand"] + " " + response["car"]["model"]);
            $("#registrationNumber").text(response["car"]["stateNumber"]);
            $("#vinNumber").text(response["car"]["vin"]);
            $("#year").text(response["car"]["manufactureYear"]);
            $("#mileAge").text(response["car"]["mileage"] + " км");
            response["workerParticipations"].forEach(element => {
                let createServiceList = `<div style="display: flex;" class="container-5">
            <div class="container-5-1" style="flex: 1; padding-left: 15px; padding-top: 20px; padding-bottom: 15px; padding-right: 15px;"; width: 350px;">
                <div class="container-5-1-1">
                    <div><p><a class="type-of-work" id="requiredService">${element["servicePosition"]["name"]}</a></p></div>
                    <div><p><a class="design-of-price1" id="costOfService">${element["servicePosition"]["price"]} руб.</a></p></div>                            
                </div>
                <div class="container-5-1-2">
                    <div class="using"><p><a class="font-style1"> Использовать запчасти:</a></p></div>
                    <div>
                        <p><a class="font-style2">товар №1</a>
                        <a class="design-of-price1">          500 руб.</a></p>
                    </div>
                    <div><a class="font-style1-1" class="space"><input type="radio" name="a" value="checked"> деталь клиента</a></div>                            
                </div>
                <div class="container-5-1-3">
                    <div>
                        <p><a class="font-style2">товар №2</a>
                        <a class="design-of-price2">1200 руб.</a></p>
                    </div>
                    <div><a class="font-style1-1" class="space"><input type="radio" name="a" value="checked" checked> деталь клиента</a></div>                            
                </div>
            </div>
            <div class="container-5-2" style="flex: 1; padding-left: 15px; padding-top: 20px; padding-bottom: 15px; padding-right: 3px;" >
                <div align="right" class="container-5-2-0"><a class="font-style3">${translateStatus(element["status"])}</a></div>
                <div class="container-5-2-1">
                    <p class="font-style1">Ответственный механик:</p>
                    <p class="font-style2" id="worker">${element["worker"] != null ? element["worker"]["surname"] : ""} ${element["worker"] != null ? element["worker"]["name"] : ""} ${element["worker"] != null ? element["worker"]["patronymic"] : ""}</p>
                </div>
                <div align="right" class="container-5-2-2"><a class="status1">Отправлено механику</a></div>
            </div>
        </div>
        <div class="container-6">
            <p class="font-style1">Комментарий механика:</p>
            <p class="font-style2">*комментариев нет*</p>
        </div>`
                $("#createServiceList").append(createServiceList);
            });
            
            $("#creation-date").text(formatDate(response["record"]["startTime"]));
            $("#completion-date").text(formatDate(response["record"]["endTime"]));
            $("#box-number").text(response["record"]["boxId"]);
            $("#total").text(response["totalPrice"] + " руб.");
        }
    });
};