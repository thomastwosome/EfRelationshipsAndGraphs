using EfRelationshipsAndGraphs.Core.Domain;
using System.Collections.Generic;

namespace EfRelationshipsAndGraphs.Core.Repositories
{
    public interface IMoeRepository : IRepository<Moe>
    {
        IEnumerable<Moe> GetMoesWithAll();
        Moe GetMoeWithAll(int moeId);
        IEnumerable<Moe> GetMostRecentMoes(int count);

        IEnumerable<Moe> GetPagedMoes(int pageIndex, int pageSize = 10);
    }
}