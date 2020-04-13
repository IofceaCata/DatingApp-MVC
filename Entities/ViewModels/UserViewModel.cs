using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Caste { get; set; }
        public string Occupation { get; set; }
        public Double Salary { get; set; }
        public MaritialStatus MaritialStatus { get; set; }
        public Religion Religion { get; set; }
        public string ImagePath { get; set; }
    }
}
