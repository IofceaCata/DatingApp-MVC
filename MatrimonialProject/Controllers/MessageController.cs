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
    public class MessageController : Controller
    {
        private int _messageId = 1;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;
        private readonly IProfileImage _profileImage;

        public MessageController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper, IProfileImage profileImage)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _profileImage = profileImage;
        }

        


        public IActionResult SelectedUserProfile(string id)
        {
            var userFromRepo = _unitOfWork.UserRepo.GetById(id);
            var mappedUser = _mapper.Map<UserViewModel>(userFromRepo);
            return View(mappedUser);
        }

        public IActionResult SendMessage()
        {
            return View();
        }
        
        

        [HttpPost]
        public IActionResult SendMessage(MessageViewModel messages)
        {
            string messageId = _messageId.ToString();
            _messageId++;
            string receiverId = TempData["recId"].ToString();
            string senderId = _userManager.GetUserId(User);
            var mappedMessage = _mapper.Map<Message>(messages);
            mappedMessage.ReceiverId = receiverId;
            mappedMessage.SenderId = senderId;
            _unitOfWork.Message.Insert(mappedMessage);
            _unitOfWork.Save();
            return View();
        }


        public IActionResult SentMessages()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var messages = _unitOfWork.Message.GetAllSentMessages(userId);

                var mappedMessage = _mapper.Map<List<MessageViewModel>>(messages);
                return View(mappedMessage);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ReceivedMessages()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var messages = _unitOfWork.Message.GetAllReceivedMessage(userId);

                var mappedMessage = _mapper.Map<List<ReceivedMessageViewModel>>(messages);
                return View(mappedMessage);
            }
            else
            {
                return View();
            }

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
