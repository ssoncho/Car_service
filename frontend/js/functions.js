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


function translateStatus(status) {
    if (status == "Planned") {
        status = "запланирован";
        return status;
    } 
    if (status == "InProcess") {
        status = "в работе";
        return status;
    } 
    if (status == "NotViewed") {
        status = "поступил";
        return status;
    }
    if (status == "Done") {
        status = "завершен";
        return status;
    }
};