using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amsystem.Data.Entities;
using Amsystem.Persistense;

namespace Amsystem.Controllers
{
    public class AgreementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgreementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Agreement
        public ActionResult AllAgreement()
        {
            var agreements = _unitOfWork.Repository<Agreement>().GetAll();
            return View(agreements);
        }
    }
}