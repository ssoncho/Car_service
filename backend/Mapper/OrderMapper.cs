using CarServiceWebConsole.DTO;

namespace CarServiceWebConsole.Mapper
{
    public static class OrderMapper
    {
        public static Order FromDto(this CreateOrderDTO orderDto)
        {
            return new Order
            {
                SiteId = orderDto.SiteId,
                ProblemDescription = orderDto.ProblemDescription,
                Status = (Status)Enum.Parse(typeof(Status), orderDto.Status, true),
                CreationDate = orderDto.CreationDate,
                CompletionDate = orderDto.CompletionDate,
                Record = orderDto.Record != null ? new Record
                {
                    BoxId = orderDto.Record.BoxId,
                    StartTime = orderDto.Record.StartTime,
                    EndTime = orderDto.Record.EndTime,
                    WorkerParticipations = orderDto.Record.WorkerParticipations.ConvertAll(workerParticipationDto => new WorkerParticipation
                    {
                        Status = (Status)Enum.Parse(typeof(Status), workerParticipationDto.Status, true),
                        Comment = workerParticipationDto.Comment,
                        MaterialPositions = workerParticipationDto.MaterialPositions.ConvertAll(materialPositionDto => new MaterialPosition
                        {
                            Name = materialPositionDto.Name,
                            Price = materialPositionDto.Price,
                            Count = materialPositionDto.Count,
                            ClientHas = materialPositionDto.ClientHas
                        }),
                        ServicePosition = new ServicePosition
                        {
                            Name = workerParticipationDto.ServicePosition.Name,
                            Price = workerParticipationDto.ServicePosition.Price
                        }
                    })
                } : null,
                Car = new Car
                {
                    Mileage = orderDto.Car.Mileage,
                    Brand = orderDto.Car.Brand,
                    Vin = orderDto.Car.Vin,
                    StateNumber = orderDto.Car.StateNumber,
                    Model = orderDto.Car.Model,
                    ManufactureYear = orderDto.Car.ManufactureYear,
                    Customer = new Customer
                    {
                        Name = orderDto.Car.Customer.Name,
                        Patronymic = orderDto.Car.Customer.Patronymic,
                        Surname = orderDto.Car.Customer.Surname,
                        PhoneNumber = orderDto.Car.Customer.PhoneNumber,
                        TelegramAlias = orderDto.Car.Customer.TelegramAlias,
                        VkAlias = orderDto.Car.Customer.VkAlias
                    }
                },
                ProductPositions = orderDto.ProductPositions.ConvertAll(productPositionDto => new ProductPosition
                {
                    Name = productPositionDto.Name,
                    Price = productPositionDto.Price,
                    Count = productPositionDto.Count
                })
            };
        }
    }
}
