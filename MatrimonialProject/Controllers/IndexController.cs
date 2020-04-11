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

namespace MatrimonialProject.Controllers
{
    public class IndexController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;
        private readonly IProfileImage _profileImage;
        public IndexController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper, IProfileImage profileImage)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _profileImage = profileImage;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
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
            else
            {
                var people = _unitOfWork.UserRepo.GetAll();
                var mappedUser = _mapper.Map<List<UserViewModel>>(people);
                return View(mappedUser);
            }
        }
    }
}