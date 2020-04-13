using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Infrastructure
{
    public interface IUnitOfWork
    {
        IMessage Message { get; }
        IUserRepo UserRepo { get; }
        void Save();
    }
}
