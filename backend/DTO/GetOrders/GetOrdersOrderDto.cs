﻿namespace CarServiceWebConsole.DTO.GetOrders
{
    public class GetOrdersOrderDto
    {
        public int OrderId { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly? CompletionDate { get; set; }
        public string Status { get; set; }
        public int TotalPrice { get; set; }
        public GetOrdersCustomerDto Customer { get; set; }
        public List<GetOrdersWorkerDto> Workers { get; set; }
    }
}