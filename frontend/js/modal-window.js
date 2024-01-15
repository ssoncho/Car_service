$.ajax({
    type: "GET",
    url: "https://5c08-178-46-122-56.ngrok-free.app/api/Workers", // URL для обработки данных на сервере
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    headers: { 
      'ngrok-skip-browser-warning': 'true' 
    },
    success: function(data) {
        console.log(data);
        workersData = data.workers; // Сохраняем полученные данные в локальный массив
        createWorkersList(workersData); // Заполняем список механиков
    },

    error: function(error) {
    console.error("Произошла ошибка при сохранении данных");
    console.log(error);
    }
});

let workersData = []; // Глобальный массив для хранения данных механиков

function createWorkersList(workers) {
    // workers.sort((a, b) => {
    //     return a.surname.localeCompare(b.surname); // Сортировка по фамилиям в алфавитном порядке
    // });

    let list = $("#mechanics-list");
    list.empty(); // Очищаем список перед добавлением новых элементов
    console.log(list)
    workers.forEach(function(worker) {  
        let fullName = worker.surname + " " + worker.name + " " + worker.patronymic;
        let listItem = $("<li>").addClass("mechanics-list-item").append($("<a>").attr("href", "#").text(fullName));
        list.append(listItem);
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
    });
};

// Обработчик событий для поля ввода поиска
$("#search").on("input", function() {
    let searchText = $(this).val().toLowerCase(); // Получаем введенный текст и приводим к нижнему регистру

    if (searchText.length === 0) {
      createWorkersList(workersData); // Возвращаем все результаты, если строка пустая
    } else {
      let filteredWorkers = workersData.filter(function(worker) {
        let fullName = (worker.surname + " " + worker.name + " " + worker.patronymic).toLowerCase();
        return fullName.includes(searchText); // Фильтруем массив механиков на основе введенного текста
      });

     createWorkersList(filteredWorkers); // Передаем отфильтрованный массив для отображения результатов поиска

    }
  });
