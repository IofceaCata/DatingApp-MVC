using MatrimonialProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Infrastructure
{
    public interface IDescription
    {
        void Insert(Description description);
        Description GetDescription(string userId);
    }
}
