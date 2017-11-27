using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amsystem.Data.Entities;
using Amsystem.Data.SqlServer.Context;
using Amsystem.Persistense.Repositories;

namespace Amsystem.Persistense
{
    public class UnitOfWork
    {
        private readonly AmsystemDbContext _dbContext;
        private Repository<Agreement> _agreementRepository;
        private Repository<Status> _statusRepository;
        private Repository<User> _userRepository;

        public UnitOfWork(AmsystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Repository<Agreement> AgreementRepository => _agreementRepository ?? (_agreementRepository = new Repository<Agreement>(_dbContext));
        public Repository<Status> StatusRepository => _statusRepository ?? (_statusRepository = new Repository<Status>(_dbContext));
        public Repository<User> UserRepository => _userRepository ?? (_userRepository = new Repository<User>(_dbContext));
    }
}
