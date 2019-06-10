using AutoMapper;

namespace EfRelationshipsAndGraphs.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Charter, MoeViewModel>()
        //            //.ForMember(d => d.CharterId, op => op.MapFrom(s => s.CharterId))
        //            //.ForMember(d => d.CharterName, op => op.MapFrom(s => s.CharterName))
        //            .ForMember(d => d.MoeId, op => op.Ignore())
        //            .ForMember(d => d.MoeName, op => op.Ignore())
        //            .ForMember(d => d.Expenditure, op => op.Ignore())
        //            .ForMember(d => d.DirectSupport, op => op.Ignore())
        //            .ForMember(d => d.Exemption, op => op.Ignore())
        //            ;

        //        cfg.CreateMap<Moe, MoeViewModel>()
        //            .ForMember(d => d.CharterName, op => op.MapFrom(s => s.Charter.CharterName));
        //        cfg.CreateMap<MoeViewModel, Moe>()
        //           .ForMember(d => d.MoeId, op => op.MapFrom(s => s.MoeId))
        //           .ForMember(d => d.MoeName, op => op.MapFrom(s => s.MoeName))
        //           .ForMember(d => d.CharterId, op => op.MapFrom(s => s.CharterId))
        //           .ForMember(d => d.Charter, op => op.Ignore())
        //           //.ForMember(d => d.Charter.CharterName, op => op.MapFrom(s => s.CharterName))
        //           //.ForMember(d => d.Expenditure, op => op.MapFrom(s => s.Expenditure))
        //           //.ForMember(d => d.DirectSupport, op => op.MapFrom(s => s.DirectSupport))
        //           //.ForMember(d => d.Exemption, op => op.MapFrom(s => s.Exemption))
        //           ;

        //        cfg.CreateMap<Expenditure, ExpenditureViewModel>();
        //        cfg.CreateMap<ExpenditureViewModel, Expenditure>()
        //            .ForMember(d => d.Moe, op => op.Ignore());

        //        cfg.CreateMap<DirectSupport, DirectSupportViewModel>();
        //        cfg.CreateMap<DirectSupportViewModel, DirectSupport>()
        //            .ForMember(d => d.Moe, op => op.Ignore());

        //        cfg.CreateMap<Exemption, ExemptionViewModel>();
        //             //.ForMember(d => d.CostlyExpendituresTotal, op => op.MapFrom(s => decimal.Parse(s.CostlyExpendituresTotal)));
        //        cfg.CreateMap<ExemptionViewModel, Exemption>()
        //            .ForMember(d => d.Moe, op => op.Ignore())
        //            .ForMember(d => d.Staffs, op => op.Ignore())
        //            .ForMember(d => d.Students, op => op.Ignore());

        //        cfg.CreateMap<CostlyExpenditure, CostlyExpenditureViewModel>();
        //        cfg.CreateMap<CostlyExpenditureViewModel, CostlyExpenditure>()
        //            .ForMember(d => d.Total, op => op.MapFrom(s => decimal.Parse(s.Total)));

        //        cfg.CreateMap<CalendarEvent, CalendarEventForm>()
        //            .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
        //            .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
        //            .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));

        //    });

        //    config.AssertConfigurationIsValid();
        }
    }
}