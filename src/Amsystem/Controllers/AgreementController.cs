﻿using System;
using System.Collections.Generic;
using System.Linq;
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