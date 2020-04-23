using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Caste { get; set; }
        public string Occupation { get; set; }
        public Double Salary { get; set; }
        public MaritialStatus MaritialStatus { get; set; }
        public Religion Religion { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Message> SentMessage { get; set; }
        public ICollection<Message> ReceiveMessage { get; set; }

        public static implicit operator ApplicationUser(string v)
        {
            throw new NotImplementedException();
        }
    }
}
namespace MatrimonialProject
{
    public enum Gender
    {
        Male,
        Female,
        Helicopter
    }
    public enum MaritialStatus
    {
        Single,
        Divorced
    }
    public enum Religion
    {
        Ortodox,
        Hindu
    }
}
