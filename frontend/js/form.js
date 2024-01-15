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
        "problemDescription": $("#reason-for-appeal").val(),
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
        url: "https://5c08-178-46-122-56.ngrok-free.app/api/Orders/", // URL для обработки данных на сервере
        data: JSON.stringify(userData), // Данные в формате JSON
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
        console.log("Данные успешно сохранены!");
        document.location = "view all applications.html"
        },
        error: function(error) {
        console.error("Произошла ошибка при сохранении данных");
        console.log(error);
        }
    });
});

//клонирование при нажатии на кнопку "добавить услугу"

$(".button2").on("click", function() {
    let originalBlock = $("#createService");
    let clonedBlock = originalBlock.clone();
    clonedBlock.find(".mechanic").val("");
    clonedBlock.find(".requiredService").val("");
    clonedBlock.find(".costOfService").val("");
    $("#createServiceList").append(clonedBlock);    
    let formTopPosition = clonedBlock.offset().top;
    $('html, body').animate({
        scrollTop: formTopPosition
      }, 500);
        
    // На клик по кнопке открывается модальное окно для выбора механика
    let currenPosition;
    $(".button3").on("click", function() { 
        currenPosition = $(window).scrollTop();
        $(".modal").css("display", "block");
        $(".mechanics-list li").css("font-weight", "normal");
        let currentService = $(this).closest(".createService"); // Находим родительскую услугу только внутри клонированного блока
        $(".activeService").removeClass("activeService");  // убрать класс у прошлого выделенного
        currentService.addClass("activeService");
    }); //МОЖНО КАК-ТО ИСКАТЬ ЭТОТ КЛАСС НЕ СРЕДИ ВСЕХ, А СРЕДИ CLONEDBLOCK?

    // Закрыть модальное окно по клику на крестик
    $(".close").on("click", function() {
        $("#myModal").css("display", "none");
    });

    // Закрыть модальное окно при клике вне его
    $(window).on("click", function(event) {
        if ($(event.target).hasClass('modal')) {
            $(".modal").css("display", "none");
        };
    });

    // Выбор механика из модального окна
    $(".mechanics-list li").on("click", function() {
        $(".mechanics-list li").css("font-weight", "normal"); // Сбрасываем стиль всех механиков
        $(this).css("font-weight", "bold"); // Устанавливаем жирный шрифт для выбранного механика
    });


    $(".save-mechanic-button").on("click", function() {     
        let selectedMechanic = $(".mechanics-list li").filter(function() {
            return $(this).css("font-weight") === "700"; // Поиск выбранного механика с жирным шрифтом
        }).text();
        $(".activeService .mechanic").val(selectedMechanic); // Записываем имя выбранного механика в поле ввода               
        $(".modal").css("display", "none");   
        $('html, body').animate({
            scrollTop: $(document).height()
        }, 1);
    });

    $(".costOfService").on("change", function() {
        let sum = 0;
        $(".costOfService").each(function() {
            sum += parseInt($(this).val());
        });
        $("#total").val(sum);
    });
});

$("#total").val(0);
$(".costOfService").on("change", function() {
    let sum = 0;
    $(".costOfService").each(function() {
        sum += parseInt($(this).val());
    });
    $("#total").val(sum);
});



// На клик по кнопке открывается модальное окно для выбора механика
$(".button3").on("click", function() {
    $(".modal").css("display", "block");
    $(".createService").removeClass("activeService");  // убрать класс у прошлого выделенного
    $(this).closest(".createService").addClass("activeService");
});

// Закрыть модальное окно по клику на крестик
$(".close").on("click", function() {
    $("#myModal").css("display", "none");
});

// Закрыть модальное окно при клике вне его
$(window).on("click", function(event) {
    if (event.target === document.getElementById("myModal")) {
        $(".modal").css("display", "none");
    };
});


// Выбор механика из модального окна
// $(".mechanics-list li").on("click", function() {
//     $(".mechanics-list li").css("font-weight", "normal"); // Сбрасываем стиль всех механиков
//     $(this).css("font-weight", "bold"); // Устанавливаем жирный шрифт для выбранного механика
//   });

//   $("#save-mechanic-button").on("click", function() {
//     let selectedMechanic = $(".mechanics-list li").filter(function() {
//       return $(this).css("font-weight") === "700"; // Поиск выбранного механика с жирным шрифтом
//     }).text();
//     $("#mechanic").val(selectedMechanic); // Записываем имя выбранного механика в поле ввода
//     $("#myModal").css("display", "none");
//   });