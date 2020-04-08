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
    public class MessageController : Controller
    {

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

        [HttpPost]
        public IActionResult SendMessage(MessageViewModel messages)
        {
            string receiverId = TempData["recId"].ToString();
            string senderId = _userManager.GetUserId(User);
            var mappedMessage = _mapper.Map<Message>(messages);
            mappedMessage.ReceiverId = senderId;
            mappedMessage.SenderId = senderId;
            _unitOfWork.Message.Insert(mappedMessage);
            _unitOfWork.Save();
            return View();
        }

        public IActionResult SentMessages()
        {
            if (User.Identity.IsAuthenticated)
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
    }
}