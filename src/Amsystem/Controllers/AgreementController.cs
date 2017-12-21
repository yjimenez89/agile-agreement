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

        // GET: AllAgreements
        public ActionResult AllAgreement()
        {
            var agreements = _unitOfWork.Repository<Agreement>().GetAll();
            return View(agreements);
        }

        public ActionResult AddAgreement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAgreement(Agreement agreement)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Agreement>().Add(agreement);
                _unitOfWork.SaveChanges();
            }
            return View();
        }
    }
}