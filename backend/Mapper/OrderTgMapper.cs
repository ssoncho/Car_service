using CarServiceWebConsole.DTO.GetOrderByIdTg;
using CarServiceWebConsole.DTO.GetOrdersIdsByTgAlias;

namespace CarServiceWebConsole.Mapper
{
    public static class OrderTgMapper
    {
        public static GetOrdersIdsByTgAliasDto ToDto(this List<int> ordersIds)
        {
            return new GetOrdersIdsByTgAliasDto
            {
                OrdersIds = ordersIds
            };
        }

        public static GetOrderByIdTgDto ToDto(this Order order)
        {
            return new GetOrderByIdTgDto
            {
                Id = order.Id,
                ProblemDescription = order.ProblemDescription,
                Status = order.Status.ToString(),
                BoxId = order.Record != null ? order.Record.BoxId : null,
                StartTime = order.Record != null ? order.Record.StartTime.ToLocalTime() : null,
                EndTime = order.Record != null ? order.Record.EndTime.ToLocalTime() : null,
                Services = order.WorkerParticipations.ConvertAll(wp => new ServiceTgDto
                {
                    Name = wp.ServicePosition.Name,
                    Status = wp.Status.ToString(),
                    Comment = wp.Comment
                })
            };
        }
    }
}
