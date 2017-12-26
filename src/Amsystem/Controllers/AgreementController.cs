using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amsystem.Data.Entities;
using Amsystem.Persistense;
using Amsystem.Services;

namespace Amsystem.Controllers
{
    public class AgreementController : Controller
    {
        private readonly IService<Agreement> _agreementService;

        public AgreementController(IService<Agreement> agreementService)
        {
            _agreementService = agreementService;
        }

        // GET: AllAgreements
        public ActionResult AllAgreement()
        {
            var agreements = _agreementService.GetAll();
            return View(agreements);
        }

        public ActionResult AddAgreement()
        {
            return View();
        }

        public ActionResult EditAgreement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = _agreementService.Get(x => x.Id == id);
            if (agreement == null)
            {
                return HttpNotFound();
            }

            return View(agreement);
        }

        [HttpPost]
        public ActionResult EditAgreement(Agreement agreement)
        {
            if (ModelState.IsValid)
            {
                _agreementService.Update(agreement);
                return RedirectToAction("AllAgreement");
            }

            return View(agreement);
        }

        [HttpPost]
        public ActionResult AddAgreement(Agreement agreement)
        {
            if (ModelState.IsValid)
            {
               _agreementService.Create(agreement);
            }
            return View();
        }
    }
}