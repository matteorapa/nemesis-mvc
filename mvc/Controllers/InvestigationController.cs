﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.ViewModels;

namespace mvc.Controllers
{
    public class InvestigationController : Controller
    {
        private readonly IInvestigationRepository _investigationRepository;

        public InvestigationController(IInvestigationRepository investigationRepository)
        {
            _investigationRepository = investigationRepository;
        }

        [Authorize(Roles = "Investigator")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "All Investigations";
            var model = new InvestigationListViewModel();
            model.Investigations = _investigationRepository.GetAllInvestigations();
            model.TotalInvestigations = model.Investigations.Count();
            return View(model);
        }

        [Authorize(Roles = "Investigator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Investigator")]
        [HttpPost]
        public IActionResult Create([Bind("DateOfAction", "InvestigatorEmail", "InvestigatorPhone", "InvDescription")] EditInvestigation vInvestigation, int id)
        {
            if (ModelState.IsValid)
            {
                Investigation i = new Investigation()
                {
                    DateOfAction = vInvestigation.DateOfAction,
                    InvestigatorEmail = vInvestigation.InvestigatorEmail,
                    InvestigatorPhone = vInvestigation.InvestigatorPhone,
                    InvDescription = vInvestigation.InvDescription,
                    ReportId = id,
                };

                _investigationRepository.CreateInvestigation(i);

                return RedirectToAction("Index");
            }

            else
            {
                return this.View(vInvestigation);
            }

        }       

        [HttpGet]
        public IActionResult Details(int id)
        {
            var inv = _investigationRepository.GetInvestigationByReportId(id);

            if (inv == null)
            {
                var model = new NewInvestigationViewModel();
                model.ReportId = id;
                return View("Views/Investigation/NoInvestigation.cshtml", model);
            }
            else
                return View(inv);
        }

        [Authorize(Roles = "Investigator")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var inv = _investigationRepository.GetInvestigationByReportId(id);

            EditInvestigation editInv = new EditInvestigation();
            editInv.DateOfAction = inv.DateOfAction;
            editInv.InvDescription = inv.InvDescription;
            editInv.InvestigatorEmail = inv.InvestigatorEmail;
            editInv.InvestigatorPhone = inv.InvestigatorPhone;

            return View(editInv);
        }

        [Authorize(Roles = "Investigator")]
        [HttpPut]
        public IActionResult Edit([Bind("DateOfAction", "InvestigatorEmail", "InvestigatorPhone", "InvDescription")] EditInvestigation vInvestigation, int id)
        {
            //todo
            return RedirectToAction("Index");
        }

       

        [Authorize(Roles = "Investigator")]
        [HttpGet]
        public IActionResult Users(IdentityUser u)
        {
            ViewBag.Title = "All Investigations";
            var model = new InvestigationListViewModel();
            model.Investigations = _investigationRepository.GetAllInvestigations();
            model.TotalInvestigations = model.Investigations.Count();
            return View(model);
            //get list of users

            return RedirectToAction("Index");
        }


    }
}