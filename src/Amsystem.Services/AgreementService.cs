using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Amsystem.Data.Entities;
using Amsystem.Persistense;

namespace Amsystem.Services
{
    public class AgreementService : IService<Agreement>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgreementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Agreement> GetAll(Expression<Func<Agreement, bool>> predicate = null)
        {
            var agreements = _unitOfWork.Repository<Agreement>().GetAll();
            return agreements;
        }

        public Agreement Get(Expression<Func<Agreement, bool>> predicate)
        {
            var agreement = _unitOfWork.Repository<Agreement>().Get(predicate);
            return agreement;
        }

        public void Create(Agreement entity)
        {
            if (entity.DueDate > DateTime.Now)
            {
                Status status = _unitOfWork.Repository<Status>().Get(x => x.Name == "Discussion");
                entity.Status = status;
            }
            else
            {
                Status status = _unitOfWork.Repository<Status>().Get(x => x.Name == "Overdue");
                entity.Status = status;
            }
            _unitOfWork.Repository<Agreement>().Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Agreement entity)
        {
            _unitOfWork.Repository<Agreement>().Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Delete(Agreement entity)
        {
            _unitOfWork.Repository<Agreement>().Delete(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
