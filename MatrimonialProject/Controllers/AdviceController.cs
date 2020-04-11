using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrimonialProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialProject.Controllers
{
    public class AdviceController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;

        public AdviceController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public async Task<IActionResult> DatingAdvice()
        {

                var user = await _userManager.GetUserAsync(User);
                if (user.Gender == Gender.Female)
                    return View("DatingAdviceWomen");
                else
                    return View();
            
        }
    }
}