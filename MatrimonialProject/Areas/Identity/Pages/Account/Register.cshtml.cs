using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MatrimonialProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MatrimonialProject.Infrastructure;
using MatrimonialProject.Repositories;
using Repository.Services;

namespace MatrimonialProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly AuthenticationServices _registerService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IProfileImage _profileImage;

        public RegisterModel(
            AuthenticationServices registerService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender , IProfileImage ProfileImage) 
            
        {
            _registerService = registerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _profileImage = ProfileImage;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

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

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file , string returnUrl )
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                _profileImage.UploadImage(file);
                //ApplicationUser user = _registerService.CreateApplicationUser(file);
                //
                //var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email ,

                //        Name = Input.Name,
                //        City = Input.City,
                //        BirthDate = Input.BirthDate,
                //        Age = Input.Age,
                //        Caste = Input.Caste,
                //        Gender = Input.Gender,
                //        Occupation = Input.Occupation,
                //        Salary = Input.Salary,
                //        MaritialStatus = Input.MaritialStatus,
                //        Religion = Input.Religion,
                //        ImagePath=file.FileName }; 

                //var result = await _userManager.CreateAsync(user, Input.Password);
                IdentityResult result = await _registerService.CreateApplicationUserAsync(file , _userManager);
                ApplicationUser user = _registerService.GetUser();
                //
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
