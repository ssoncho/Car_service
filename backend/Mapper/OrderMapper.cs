using CarServiceWebConsole.DTO;
using CarServiceWebConsole.DTO.GetOrderById;

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
                    EndTime = orderDto.Record.EndTime
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
                        Name = orderDto.Customer.Name,
                        Patronymic = orderDto.Customer.Patronymic,
                        Surname = orderDto.Customer.Surname,
                        PhoneNumber = orderDto.Customer.PhoneNumber,
                        TelegramAlias = orderDto.Customer.TelegramAlias,
                        VkAlias = orderDto.Customer.VkAlias
                    }
                },
                WorkerParticipations = orderDto.WorkerParticipations.ConvertAll(workerParticipationDto => new WorkerParticipation
                {
                    WorkerId = workerParticipationDto.WorkerId,
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
                }),
                ProductPositions = orderDto.ProductPositions.ConvertAll(productPositionDto => new ProductPosition
                {
                    Name = productPositionDto.Name,
                    Price = productPositionDto.Price,
                    Count = productPositionDto.Count
                })
            };
        }

        public static GetOrderByIdResponseDto ToDto(this Order order)
        {
            return new GetOrderByIdResponseDto
            {
                OrderId = order.Id,
                SiteId = order.SiteId,
                ProblemDescription = order.ProblemDescription,
                Status = order.Status.ToString(),
                CreationDate = order.CreationDate,
                CompletionDate = order.CompletionDate,
                Car = new CarDto
                {
                    Id = order.Car.Id,
                    Mileage = order.Car.Mileage,
                    Brand = order.Car.Brand,
                    Vin = order.Car.Vin,
                    StateNumber = order.Car.StateNumber,
                    Model = order.Car.Model,
                    ManufactureYear = order.Car.ManufactureYear
                },
                Customer = new CustomerDto
                {
                    Id = order.Car.Customer.Id,
                    Name = order.Car.Customer.Name,
                    Patronymic = order.Car.Customer.Patronymic,
                    Surname = order.Car.Customer.Surname,
                    PhoneNumber = order.Car.Customer.PhoneNumber,
                    TelegramAlias = order.Car.Customer.TelegramAlias,
                    VkAlias = order.Car.Customer.VkAlias
                },
                Record = order.Record != null ? new RecordDto
                {
                    Id = order.Record.Id,
                    BoxId = order.Record.BoxId,
                    StartTime = order.Record.StartTime,
                    EndTime = order.Record.EndTime,
                } : null,
                WorkerParticipations = order.WorkerParticipations.ConvertAll(workerParticipation => new WorkerParticipationDto
                {
                    Id = workerParticipation.ServicePositionId,
                    Status = workerParticipation.Status.ToString(),
                    Comment = workerParticipation.Comment,
                    Worker = workerParticipation.Worker != null ? new WorkerDto
                    {
                        Id = workerParticipation.Worker.MobileId,
                        Name = workerParticipation.Worker.Name,
                        Patronymic = workerParticipation.Worker.Patronymic,
                        Surname = workerParticipation.Worker.Surname
                    } : null,
                    ServicePosition = new ServicePositionDto
                    {
                        Id = workerParticipation.ServicePosition.Id,
                        Name = workerParticipation.ServicePosition.Name,
                        Price = workerParticipation.ServicePosition.Price
                    },
                    MaterialPositions = workerParticipation.MaterialPositions.ConvertAll(orderRecordWorkerParticipationMaterialPosition => new MaterialPositionDto
                    {
                        Id = orderRecordWorkerParticipationMaterialPosition.Id,
                        Name = orderRecordWorkerParticipationMaterialPosition.Name,
                        Price = orderRecordWorkerParticipationMaterialPosition.Price,
                        Count = orderRecordWorkerParticipationMaterialPosition.Count,
                        ClientHas = orderRecordWorkerParticipationMaterialPosition.ClientHas
                    })
                }),
                ProductPositions = order.ProductPositions.ConvertAll(productPosition => new ProductPositionDto
                {
                    Id = productPosition.Id,
                    Name = productPosition.Name,
                    Price = productPosition.Price,
                    Count = productPosition.Count
                })
            };
        }
    }
}
