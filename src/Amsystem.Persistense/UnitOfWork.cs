using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amsystem.Data.Entities;
using Amsystem.Data.Repositories;
using Amsystem.Data.SqlServer.Context;
using Amsystem.Persistense.Repositories;

namespace Amsystem.Persistense
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AmsystemDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(AmsystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            IRepository<TEntity> repo = new Repository<TEntity>(_dbContext);
            _repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
