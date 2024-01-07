$("#saveButton").on("click", function() {
    let workerParticipations = [];
    $(".createService").each(function() {
        workerParticipations.push(
            {
            "worker": ($(this).find(".mechanic").val() == "") ? null : {
                "name": $(this).find(".mechanic").val().split(" ")[1],
                "patronymic":  $(this).find(".mechanic").val().split(" ")[2],
                "surname":  $(this).find(".mechanic").val().split(" ")[0]
            },
            "status": "notViewed",
            "materialPositions": [],
            "servicePosition": {
                "name":  $(this).find(".requiredService").val(),
                "price":  $(this).find(".costOfService").val()
            }
            }
        );       
    });

    let userData = {
        "problemDescription": "",
        "status": "notViewed",
        "car": {
            "mileage": $("#mileAge").val(),
            "brand": $("#carModel").val().split(" ")[0],
            "vin": $("#vinNumber").val(),
            "stateNumber": $("#registrationNumber").val(),
            "model": $("#carModel").val().split(" ")[1],
            "manufactureYear": $("#year").val()
        },
        "customer": {
            "name": $("#nameOfPerson").val().split(" ")[1],
            "patronymic": $("#nameOfPerson").val().split(" ")[2],
            "surname": $("#nameOfPerson").val().split(" ")[0],
            "phoneNumber": $("#phoneNumber").val(),
            "telegramAlias": $("#tgAlias").val(),
            "vkAlias": $("#vkAlias").val()
        },
        "record": {
            "boxId": $("#box").val(),
            "startTime": $("#arrivalOfClient").val().replace(/(\d{2}).(\d{2}).(\d{4}) (\d{2}):(\d{2})/, '$3-$2-$1T$4:$5:00'),
            "endTime": $("#orderFulfilment").val().replace(/(\d{2}).(\d{2}).(\d{4}) (\d{2}):(\d{2})/, '$3-$2-$1T$4:$5:00')
        },
        "workerParticipations": workerParticipations,
        "productPositions": []
    }

    console.log(userData);
    console.log(JSON.stringify(userData));

    // Отправка данных на сервер
    $.ajax({
        type: "POST",
        url: "https://9e9a-90-151-96-105.ngrok-free.app/api/Orders/", // URL для обработки данных на сервере
        data: JSON.stringify(userData), // Данные в формате JSON
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
        console.log("Данные успешно сохранены!");
        },
        error: function(error) {
        console.error("Произошла ошибка при сохранении данных");
        console.log(error);
        }
    });
});


//клонирование при нажатии на кнопку "добавить услугу"

$("#duplicateButton").on("click", function() {
    var originalBlock = $("#createService");
    var clonedBlock = originalBlock.clone();
    clonedBlock.find(".mechanic").val("");
    clonedBlock.find(".requiredService").val("");
    clonedBlock.find(".costOfService").val("");
    $("#createServiceList").append(clonedBlock);
    
    $(".costOfService").on("change", function() {
        let sum = 0;
        $(".costOfService").each(function() {
            sum += parseInt($(this).val());
        });
        $("#total").val(sum);
    });
});

$(".costOfService").on("change", function() {
    let sum = 0;
    $(".costOfService").each(function() {
        sum += parseInt($(this).val());
    });
    $("#total").val(sum);
});
