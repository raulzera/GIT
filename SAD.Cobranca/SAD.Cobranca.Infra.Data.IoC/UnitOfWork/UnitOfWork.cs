using System;
using SAD.Cobranca.Infra.Data.IoC.Context;

namespace SAD.Cobranca.Infra.Data.IoC.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _disposed = false;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

