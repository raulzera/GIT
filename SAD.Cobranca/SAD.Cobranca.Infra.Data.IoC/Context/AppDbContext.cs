using System.Data.Entity;

namespace SAD.Cobranca.Infra.Data.IoC.Context
{
    public class AppDbContext<TEntity> where TEntity : class
    {
            protected readonly ApplicationDbContext Db;
            private readonly DbSet<TEntity> _dbSet;

            protected AppDbContext(ApplicationDbContext context)
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                Db = context;
                _dbSet = Db.Set<TEntity>();
            }
        }
}
