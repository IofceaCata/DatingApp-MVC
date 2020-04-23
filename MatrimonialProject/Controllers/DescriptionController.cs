using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatrimonialProject.Infrastructure;
using MatrimonialProject.Models;
using MatrimonialProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MatrimonialProject.Controllers
{
    public class DescriptionController : Controller
    {

        private IMapper _mapper;
        private int _descriptionId = 3;
        private IDescription _description;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public DescriptionController(IDescription description, UserManager<ApplicationUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _description = description;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(DescriptionViweModel description)
        {
            _descriptionId++;
            string descriptionId = _descriptionId.ToString();
           
            string UserId = _userManager.GetUserId(User);
            var mappedDescription = _mapper.Map<Description>(description);
            mappedDescription.DescriptionId = descriptionId;
          
            mappedDescription.UserId = UserId;
            
            _unitOfWork.Description.Insert(mappedDescription);
            _unitOfWork.Save();

            
            return View();
        }

        public ActionResult ViewMyDescription()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var description = _unitOfWork.Description.GetDescription(userId);

                var mappedDescription = _mapper.Map<DescriptionViweModel>(description);
                return View(mappedDescription);
            }
            else
            {
                return View();
            } 
        }
        public ActionResult ViewDescription()
        {
            
           if (User.Identity.IsAuthenticated)
            {
                string userId = TempData["recId"].ToString();//_userManager.GetUserId(User);
                
                var description = _unitOfWork.Description.GetDescription(userId);
                
                var mappedDescription = _mapper.Map<DescriptionViweModel>(description);
                
                return View(mappedDescription);
                
                
            }
            else
            {
                return View();
            }
        }

        
    }
}