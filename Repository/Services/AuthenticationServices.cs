using MatrimonialProject;
using MatrimonialProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.ExternalLoginModel;

namespace Repository.Services
{
    public class AuthenticationServices
    {
        
        ApplicationUser user;
        

        public InputModel Input { get; set; }
        public class InputModel
        {


            [Required]
            public string Name { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public DateTime BirthDate { get; set; }
            [Required]
            public int Age { get; set; }
            [Required]
            public string Caste { get; set; }
            public Gender Gender { get; set; }
            [Required]
            public string Occupation { get; set; }
            public Double Salary { get; set; }
            [Required]
            public MaritialStatus MaritialStatus { get; set; }
            public string ImagePath { get; set; }
            public Religion Religion { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void Logout(SignInManager<ApplicationUser> signInManager)
        {
            signInManager.SignOutAsync();
        }

        public async System.Threading.Tasks.Task<IdentityResult> CreateApplicationUserAsync(IFormFile file, UserManager<ApplicationUser> userManager)
        {
            
            ApplicationUser user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email,
                Name = Input.Name,
                City = Input.City,
                BirthDate = Input.BirthDate,
                Age = Input.Age,
                Caste = Input.Caste,
                Gender = Input.Gender,
                Occupation = Input.Occupation,
                Salary = Input.Salary,
                MaritialStatus = Input.MaritialStatus,
                Religion = Input.Religion,
                ImagePath = file.FileName
            };

            this.user = user;
            return await userManager.CreateAsync(user, Input.Password);
            
        }

        public ApplicationUser GetUser()
        {
            return user;
        }
        public async System.Threading.Tasks.Task<SignInResult> LogInAsync(SignInManager<ApplicationUser> signInManager,string Email,string Password,Boolean RememberMe,Boolean lockoutOnFailure)
        {
           return await signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure);
        }
    }
}
