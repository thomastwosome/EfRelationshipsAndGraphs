using EfRelationshipsAndGraphs.Persistance.Repositories;
using EfRelationshipsAndGraphs.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using EfRelationshipsAndGraphs.Core.Domain;

namespace EfRelationshipsAndGraphs.Persistance.Repositories
{
    public class MoeRepository : Repository<Moe>, IMoeRepository
    {
        public MoeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Moe> GetMoesWithAll()
        {
            return ApplicationDbContext.Moes.Include("Charter").ToList();
        }

        public Moe GetMoeWithAll(int moeId)
        {
            return ApplicationDbContext.Moes
                .Include("Charter")
                .Include("Expenditure")
                //.Include("DirectSupport")
                //.Include("Exemption")
                .Where(x => x.MoeId == moeId).FirstOrDefault();
        }

        public IEnumerable<Moe> GetMostRecentMoes(int count)
        {
            return ApplicationDbContext.Moes.OrderByDescending(x => x.MoeId).Take(count).ToList();
        }

        public IEnumerable<Moe> GetPagedMoes(int pageIndex, int pageSize = 10)
        {
            return ApplicationDbContext.Moes
                .OrderBy(x => x.MoeId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}