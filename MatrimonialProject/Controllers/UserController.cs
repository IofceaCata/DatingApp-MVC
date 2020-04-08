using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MatrimonialProject.Models;
using MatrimonialProject.Infrastructure;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using MatrimonialProject.ViewModels;

namespace MatrimonialProject.Controllers
{
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;
        private readonly IProfileImage _profileImage;

        public UserController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper, IProfileImage profileImage)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _profileImage = profileImage;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWork;
        }

        public UserManager<ApplicationUser> GetUserManager()
        {
            return _userManager;
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }
        public IProfileImage GetprofileImage()
        {
            return _profileImage;
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


        public IActionResult SelectedUserProfile(string id)
        {
            var userFromRepo = _unitOfWork.UserRepo.GetById(id);
            var mappedUser = _mapper.Map<UserViewModel>(userFromRepo);
            return View(mappedUser);
        }

        

        public IActionResult SearchCategory()
        {
            return View();
        }

        

        [HttpPost]

        public IActionResult SearchCategory(SearchViewModel vm)
        {
            if(vm.Selected == 0)
            {
                ViewBag.showResults = true;
                var users = _unitOfWork.UserRepo.GetAgeUser(Convert.ToInt32(vm.Min), Convert.ToInt32(vm.Max));
                vm.Users = _mapper.Map<List<UserViewModel>>(users);

                return View(vm);
            }
            if (vm.Selected == 1)
            {
                ViewBag.showResults = true;
                var users = _unitOfWork.UserRepo.UserBySalary(Convert.ToInt32(vm.Min), Convert.ToInt32(vm.Max));
                vm.Users = _mapper.Map<List<UserViewModel>>(users);

                return View(vm);
            }
            return View();

        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
