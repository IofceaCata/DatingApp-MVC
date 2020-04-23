using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatrimonialProject.Infrastructure;
using MatrimonialProject.Models;
using MatrimonialProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MatrimonialProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public SearchController(IUnitOfWork unitOfWork,  IMapper mapper , UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        
        public async  Task<IActionResult> SearchCategory()
        {
            return View();
        }

        
        
        public async Task<IActionResult> SearchResult(SearchViewModel model)
        {


            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {

                ViewBag.Message = model.Max;
                ViewBag.Message2 = model.Min;
                if (user.Gender == Gender.Female)
                {
                    var onlyMales = _unitOfWork.UserRepo.GetAllMales();
                    var mappedUser = _mapper.Map<List<UserViewModel>>(onlyMales);
                    return View(mappedUser);
                }
                else
                {
                    var onlyFemales = _unitOfWork.UserRepo.GetAllFemales();
                    var mappedUser = _mapper.Map<List<UserViewModel>>(onlyFemales);
                    return View(mappedUser);
                }
            }
            return View();
        }

        

    }
}