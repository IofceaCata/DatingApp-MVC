using MatrimonialProject.Data;
using MatrimonialProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private IUserRepo _userRepo;
        private readonly ApplicationDbContext _context;
        private IMessage _message;

        public IUserRepo UserRepo
        {
            get
            {
                return _userRepo = _userRepo ?? new UserRepo(_context);
            }
        }
        public IMessage Message
        {
            get
            {
                return _message = _message ?? new MessageRepo(_context);
            }
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
