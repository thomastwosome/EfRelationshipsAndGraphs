using AutoMapper;
using EfRelationshipsAndGraphs.Core.Domain;
using EfRelationshipsAndGraphs.ViewModels;
using System.Collections.Generic;

namespace EfRelationshipsAndGraphs
{
    public static class MappingExtensions
    {
        public static MoeViewModel ToModel(this Charter entity)
        {
            return Mapper.Map<Charter, MoeViewModel>(entity);
        }

        #region MOE

        public static MoeViewModel ToModel(this Moe entity)
        {
            var model =  Mapper.Map<Moe, MoeViewModel>(entity);
            if (entity.Expenditure != null)
            {
                Mapper.Map<Expenditure, MoeViewModel>(entity.Expenditure);
            }
            if (entity.DirectSupport != null)
            {
                Mapper.Map<DirectSupport, MoeViewModel>(entity.DirectSupport);

            }
            return model;
        }

        public static Moe ToEntity(this MoeViewModel model)
        {
            var entity = Mapper.Map<MoeViewModel, Moe>(model);
            return entity;
        }

        public static Moe ToEntity(this MoeViewModel model, Moe entity)
        {
            return Mapper.Map(model, entity);
        }

        public static IEnumerable<MoeViewModel> ToCollection(this IEnumerable<Moe> entities)
        {
            return Mapper.Map<IEnumerable<Moe>, IEnumerable<MoeViewModel>>(entities);
        }

        #endregion

        //#region Expenditure

        //public static ExpenditureViewModel ToModel(this Expenditure entity)
        //{
        //    return Mapper.Map<Expenditure, ExpenditureViewModel>(entity);
        //}

        //public static Expenditure ToEntity(this ExpenditureViewModel model)
        //{
        //    return Mapper.Map<ExpenditureViewModel, Expenditure>(model);
        //}

        //public static Expenditure ToEntity(this ExpenditureViewModel model, Expenditure entity)
        //{
        //    return Mapper.Map(model, entity);
        //}

        //public static IEnumerable<ExpenditureViewModel> ToCollection(this IEnumerable<Expenditure> entities)
        //{
        //    return Mapper.Map<IEnumerable<Expenditure>, IEnumerable<ExpenditureViewModel>>(entities);
        //}

        //#endregion

        //#region Direct Support

        //public static DirectSupportViewModel ToModel(this DirectSupport entity)
        //{
        //    return Mapper.Map<DirectSupport, DirectSupportViewModel>(entity);
        //}

        //public static DirectSupport ToEntity(this DirectSupportViewModel model)
        //{
        //    return Mapper.Map<DirectSupportViewModel, DirectSupport>(model);
        //}

        //public static DirectSupport ToEntity(this DirectSupportViewModel model, DirectSupport entity)
        //{
        //    return Mapper.Map(model, entity);
        //}

        //public static IEnumerable<DirectSupportViewModel> ToCollection(this IEnumerable<DirectSupport> entities)
        //{
        //    return Mapper.Map<IEnumerable<DirectSupport>, IEnumerable<DirectSupportViewModel>>(entities);
        //}

        //#endregion

        //#region Exemptions

        //public static ExemptionViewModel ToModel(this Exemption entity)
        //{
        //    return Mapper.Map<Exemption, ExemptionViewModel>(entity);
        //}

        //public static Exemption ToEntity(this ExemptionViewModel model)
        //{
        //    return Mapper.Map<ExemptionViewModel, Exemption>(model);
        //}

        //public static Exemption ToEntity(this ExemptionViewModel model, Exemption entity)
        //{
        //    return Mapper.Map(model, entity);
        //}

        //public static IEnumerable<ExemptionViewModel> ToCollection(this IEnumerable<Exemption> entities)
        //{
        //    return Mapper.Map<IEnumerable<Exemption>, IEnumerable<ExemptionViewModel>>(entities);
        //}

        //#endregion

        //#region Costly Expenditures

        //public static CostlyExpenditureViewModel ToModel(this CostlyExpenditure entity)
        //{
        //    return Mapper.Map<CostlyExpenditure, CostlyExpenditureViewModel>(entity);
        //}

        //public static CostlyExpenditure ToEntity(this CostlyExpenditureViewModel model)
        //{
        //    return Mapper.Map<CostlyExpenditureViewModel, CostlyExpenditure>(model);
        //}

        //public static CostlyExpenditure ToEntity(this CostlyExpenditureViewModel model, CostlyExpenditure entity)
        //{
        //    return Mapper.Map(model, entity);
        //}

        //public static IEnumerable<CostlyExpenditureViewModel> ToCollection(this IEnumerable<CostlyExpenditure> entities)
        //{
        //    return Mapper.Map<IEnumerable<CostlyExpenditure>, IEnumerable<CostlyExpenditureViewModel>>(entities);
        //}

        //#endregion
    }
}