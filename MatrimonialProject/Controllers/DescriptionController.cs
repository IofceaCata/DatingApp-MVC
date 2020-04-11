using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrimonialProject.Infrastructure;
using MatrimonialProject.Models;
using MatrimonialProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialProject.Controllers
{
    public class DescriptionController : Controller
    {
        /*
        private IDescription _description;
        private readonly UserManager<ApplicationUser> _userManager;

        public DescriptionController(IDescription description, UserManager<ApplicationUser> userManager)
        {
            _description = description;
            _userManager = userManager;
        }*/

        // GET: Description
        public ActionResult Index()
        {
            return View();
        }

        // GET: Description/Details/5
        public ActionResult CreateDescription()
        {
            return View();
        }
        /*
        // GET: Description/Create
        public ActionResult Create(DescriptionViweModel description)
        {
            string UserId = TempData["userId"].ToString();
            string senderId = _userManager.GetUserId(User);
            var mappedDescription = _description;
            return View();
        }

        // POST: Description/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Description/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Description/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Description/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Description/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}