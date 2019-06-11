using AutoMapper;
using EfRelationshipsAndGraphs.Core.Domain;
using EfRelationshipsAndGraphs.ViewModels;

namespace EfRelationshipsAndGraphs
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Charter, MoeViewModel>()
                .ForMember(d => d.MoeId, op => op.Ignore())
                .ForMember(d => d.MoeName, op => op.Ignore())
                .ForMember(d => d.ActualOrBudget, op => op.Ignore())
                .ForMember(d => d.RelatedMoeId, op => op.Ignore())
                .ForMember(d => d.ExpenditureId, op => op.Ignore())
                .ForMember(d => d.ExpenditureName, op => op.Ignore())
                .ForMember(d => d.Expenditure, op => op.Ignore())
                .ForMember(d => d.DirectSupportId, op => op.Ignore())
                .ForMember(d => d.DirectSupportName, op => op.Ignore())
                .ForMember(d => d.DirectSupport, op => op.Ignore())
                .ForMember(d => d.ExemptionId, op => op.Ignore())
                .ForMember(d => d.ExemptionName, op => op.Ignore())
                .ForMember(d => d.Exemption, op => op.Ignore())
            ;

            Mapper.CreateMap<Moe, MoeViewModel>()
                .ForMember(d => d.CharterName, op => op.MapFrom(s => s.Charter.CharterName))
                .ForMember(d => d.ExpenditureId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.ExpenditureName, op => op.MapFrom(s => s.Expenditure.Name))
                .ForMember(d => d.DirectSupportId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.DirectSupportName, op => op.MapFrom(s => s.DirectSupport.Name))
                .ForMember(d => d.ExemptionId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.ExemptionName, op => op.MapFrom(s => s.Exemption.Name))
            ;

            Mapper.CreateMap<Expenditure, MoeViewModel>()
                .ForMember(d => d.MoeId, op => op.Ignore())
                .ForMember(d => d.MoeName, op => op.Ignore())
                .ForMember(d => d.ActualOrBudget, op => op.Ignore())
                .ForMember(d => d.RelatedMoeId, op => op.Ignore())
                .ForMember(d => d.CharterId, op => op.Ignore())
                .ForMember(d => d.CharterName, op => op.Ignore())
                .ForMember(d => d.Expenditure, op => op.Ignore())
                .ForMember(d => d.DirectSupportId, op => op.Ignore())
                .ForMember(d => d.DirectSupportName, op => op.Ignore())
                .ForMember(d => d.DirectSupport, op => op.Ignore())
                .ForMember(d => d.ExemptionId, op => op.Ignore())
                .ForMember(d => d.ExemptionName, op => op.Ignore())
                .ForMember(d => d.Exemption, op => op.Ignore())
            ;

            Mapper.CreateMap<DirectSupport, MoeViewModel>()
                .ForMember(d => d.MoeId, op => op.Ignore())
                .ForMember(d => d.MoeName, op => op.Ignore())
                .ForMember(d => d.ActualOrBudget, op => op.Ignore())
                .ForMember(d => d.RelatedMoeId, op => op.Ignore())
                .ForMember(d => d.CharterId, op => op.Ignore())
                .ForMember(d => d.CharterName, op => op.Ignore())
                .ForMember(d => d.ExpenditureId, op => op.Ignore())
                .ForMember(d => d.ExpenditureName, op => op.Ignore())
                .ForMember(d => d.Expenditure, op => op.Ignore())
                .ForMember(d => d.DirectSupport, op => op.Ignore())
                .ForMember(d => d.ExemptionId, op => op.Ignore())
                .ForMember(d => d.ExemptionName, op => op.Ignore())
                .ForMember(d => d.Exemption, op => op.Ignore())
                ;

            Mapper.CreateMap<Exemption, MoeViewModel>()
                .ForMember(d => d.MoeId, op => op.Ignore())
                .ForMember(d => d.MoeName, op => op.Ignore())
                .ForMember(d => d.ActualOrBudget, op => op.Ignore())
                .ForMember(d => d.RelatedMoeId, op => op.Ignore())
                .ForMember(d => d.CharterId, op => op.Ignore())
                .ForMember(d => d.CharterName, op => op.Ignore())
                .ForMember(d => d.ExpenditureId, op => op.Ignore())
                .ForMember(d => d.ExpenditureName, op => op.Ignore())
                .ForMember(d => d.Expenditure, op => op.Ignore())
                .ForMember(d => d.DirectSupport, op => op.Ignore())
                .ForMember(d => d.DirectSupportId, op => op.Ignore())
                .ForMember(d => d.DirectSupportName, op => op.Ignore())
                .ForMember(d => d.Exemption, op => op.Ignore())
                ;

            Mapper.CreateMap<MoeViewModel, Moe>() //moe = model.ToEntity()
                .ForMember(d => d.MoeId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.MoeName))
                .ForMember(d => d.CharterId, op => op.MapFrom(s => s.CharterId))
                .ForMember(d => d.Charter, op => op.Ignore())
                .ForMember(d => d.Expenditure, op => op.MapFrom(s => s.Expenditure))
                .ForMember(d => d.DirectSupport, op => op.MapFrom(s => s.DirectSupport))
                .ForMember(d => d.Exemption, op => op.MapFrom(s => s.Exemption))
            ;

            Mapper.CreateMap<MoeViewModel, Expenditure>()
                .ForMember(d => d.Moe, op => op.Ignore())
                .ForMember(d => d.ExpenditureId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.ExpenditureName))
            ;

            Mapper.CreateMap<MoeViewModel, DirectSupport>()
                .ForMember(d => d.Moe, op => op.Ignore())
                .ForMember(d => d.DirectSupportId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.DirectSupportName))
                ;

            Mapper.CreateMap<MoeViewModel, Exemption>()
                .ForMember(d => d.Moe, op => op.Ignore())
                .ForMember(d => d.ExemptionId, op => op.MapFrom(s => s.MoeId))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.ExemptionName))
                ;

            //Mapper.CreateMap<Exemption, ExemptionViewModel>();
            ////.ForMember(d => d.CostlyExpendituresTotal, op => op.MapFrom(s => decimal.Parse(s.CostlyExpendituresTotal)));
            //Mapper.CreateMap<ExemptionViewModel, Exemption>()
            //    .ForMember(d => d.Moe, op => op.Ignore())
            //    //.ForMember(d => d.Staffs, op => op.Ignore())
            //    //.ForMember(d => d.Students, op => op.Ignore())
            //    ;

            ////Mapper.CreateMap<CostlyExpenditure, CostlyExpenditureViewModel>();
            ////Mapper.CreateMap<CostlyExpenditureViewModel, CostlyExpenditure>()
            ////    .ForMember(d => d.Total, op => op.MapFrom(s => decimal.Parse(s.Total)));

            //Mapper.CreateMap<CalendarEvent, CalendarEventForm>()
            //    .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
            //    .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
            //    .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));

            Mapper.AssertConfigurationIsValid();

        }
    }
}