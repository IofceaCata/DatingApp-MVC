using MatrimonialProject.Data;
using MatrimonialProject.Infrastructure;
using MatrimonialProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<ApplicationUser> GetAgeUser(int min, int max)
        {
            return _context.Users.Where(x => x.Age > min && x.Age < max).ToList();
        }

        public IList<ApplicationUser> GetAll()
        {
            return _context.Users.ToList();
        }

        public IList<ApplicationUser> GetAllFemales()
        {
            return _context.Users.Where(x => x.Gender == Gender.Female).ToList();
        }

        public IList<ApplicationUser> GetAllMales()
        {
            return _context.Users.Where(x => x.Gender == Gender.Male).ToList();
        }

        public ApplicationUser GetById(string Id)
        {
            return _context.Users.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<ApplicationUser> UserBySalary(int v1, int v2)
        {
            return _context.Users.Where(x => x.Salary > v1 && x.Age < v2).ToList();
        }
    }
}
