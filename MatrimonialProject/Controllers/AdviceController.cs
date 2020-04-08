using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialProject.Controllers
{
    public class AdviceController : Controller
    {
        public IActionResult DatingAdvice()
        {
            return View();
        }
    }
}