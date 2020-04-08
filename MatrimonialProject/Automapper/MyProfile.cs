using AutoMapper;
using MatrimonialProject.Models;
using MatrimonialProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Automapper
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<ApplicationUser, SearchViewModel>();
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<MessageViewModel, Message>();
            CreateMap<Message, MessageViewModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Receiver.Name));
            CreateMap<Message, ReceivedMessageViewModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Sender.Name));
        }
    }
}
