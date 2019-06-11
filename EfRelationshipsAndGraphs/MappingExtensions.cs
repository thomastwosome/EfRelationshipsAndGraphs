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
            var model = Mapper.Map<Moe, MoeViewModel>(entity);

            if (entity.Expenditure != null)
                Mapper.Map<Expenditure, MoeViewModel>(entity.Expenditure);

            if (entity.DirectSupport != null)
                Mapper.Map<DirectSupport, MoeViewModel>(entity.DirectSupport);

            if (entity.Exemption != null)
                Mapper.Map<Exemption, MoeViewModel>(entity.Exemption);

            return model;
        }

        public static Moe ToEntity(this MoeViewModel model) //Only work on CREATE, not UPDATE
        {
            var entity = Mapper.Map<MoeViewModel, Moe>(model);

            if (model.ExpenditureName != null)
                entity.Expenditure = Mapper.Map<MoeViewModel, Expenditure>(model);

            if (model.DirectSupportName != null)
                entity.DirectSupport = Mapper.Map<MoeViewModel, DirectSupport>(model);

            if (model.ExemptionName != null)
                entity.Exemption = Mapper.Map<MoeViewModel, Exemption>(model);

            return entity;
        }

        public static IEnumerable<MoeViewModel> ToCollection(this IEnumerable<Moe> entities)
        {
            return Mapper.Map<IEnumerable<Moe>, IEnumerable<MoeViewModel>>(entities);
        }

        #endregion

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