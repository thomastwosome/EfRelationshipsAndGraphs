using EfRelationshipsAndGraphs.Core;
using EfRelationshipsAndGraphs.Core.Repositories;
using EfRelationshipsAndGraphs.Persistance.Repositories;

namespace EfRelationshipsAndGraphs.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Moes = new MoeRepository(_context);
        }

        public IMoeRepository Moes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}