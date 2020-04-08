using MatrimonialProject.Data;
using MatrimonialProject.Infrastructure;
using MatrimonialProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Repositories
{
    public class MessageRepo : IMessage
    {
        private readonly ApplicationDbContext _context;

        public MessageRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        List<Message> IMessage.GetAllReceivedMessage(string userId)
        {
            return _context.Message.Include(y => y.Sender).Where(x => x.ReceiverId == userId).ToList();
        }

        public List<Message> GetAllSentMessages(string id)
        {
            return _context.Message.Include(y => y.Receiver).Where(x => x.SenderId == id).ToList();
        }

        public void Insert(Message message)
        {
            _context.Message.Add(message);
        }
    }
}
