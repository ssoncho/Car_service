using AutoMapper;
using CarServiceWebConsole.DTO;

namespace CarServiceWebConsole
{
    public class AutoMapperProfile : Profile
    {
        //public AutoMapperProfile()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<CreateCustomerDTO, Customer>();
        //        cfg.CreateMap<CreateCarDTO, Car>()
        //            .ForMember(dest => dest.Id, opt => opt.Ignore());
        //        cfg.CreateMap<CreateMaterialPositionNewOrderDTO, MaterialPosition>()
        //            .ForMember(dest => dest.Id, opt => opt.Ignore());
        //        cfg.CreateMap<CreateServicePositionNewOrderDTO, ServicePosition>()
        //            .ForMember(dest => dest.WorkerParticipationId, opt => opt.Ignore());
        //        cfg.CreateMap<CreateWorkerParticipationNewOrderDTO, WorkerParticipation>()
        //            .ForMember(dest => dest.Id, opt => opt.Ignore());
        //        cfg.CreateMap<CreateRecordDTO, Record>()
        //            .ForMember(dest => dest.OrderId, opt => opt.Ignore());
        //        cfg.CreateMap<CreateProductPositionNewOrderDTO, ProductPosition>()
        //            .ForMember(dest => dest.Id, opt => opt.Ignore());
        //        cfg.CreateMap<CreateOrderDTO, Order>()
        //            .ForMember(dest => dest.Id, opt => opt.Ignore());
        //    });
        //    config.AssertConfigurationIsValid();
        //}
    }
}
