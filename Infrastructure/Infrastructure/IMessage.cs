using MatrimonialProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Infrastructure
{
    public interface IMessage
    {
        void Insert(Message message);
        List<Message> GetAllSentMessages(string id);
        List<Message> GetAllReceivedMessage(string userId);
    }
}
