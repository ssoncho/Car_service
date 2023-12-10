using AutoMapper;
using CarServiceWebConsole.DTO;

namespace CarServiceWebConsole
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateOrderDTO, Order>();
                cfg.CreateMap<CreateCustomerDTO, Customer>();
                cfg.CreateMap<CreateCarDTO, Car>();
                cfg.CreateMap<CreateRecordDTO, Record>();
                cfg.CreateMap<CreateWorkerParticipationNewOrderDTO, WorkerParticipation>();
                cfg.CreateMap<CreateMaterialPositionNewOrderDTO, MaterialPosition>();
                cfg.CreateMap<CreateServicePositionNewOrderDTO, ServicePosition>();
                cfg.CreateMap<CreateProductPositionNewOrderDTO, ProductPosition>();
            });
        }
    }
}
