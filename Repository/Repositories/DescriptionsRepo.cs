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
    public class DescriptionsRepo : IDescription
    {
        private readonly ApplicationDbContext _context;
        public DescriptionsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Description GetDescription(string id)
        {

            return _context.Description.Single(x => x.UserId == id);
            
        }

        public void Insert(Description description)
        {
            _context.Description.Add(description);
        }
    }
}
