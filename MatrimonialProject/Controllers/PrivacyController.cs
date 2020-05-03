using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialProject.Controllers
{
    [Authorize(Roles = "Client")]
    public class PrivacyController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }
    }
}