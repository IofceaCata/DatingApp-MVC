using MatrimonialProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class EditUserViewModel
{
    public EditUserViewModel()
    {
        Claims = new List<string>();
        Roles = new List<string>();
    }

    public string Id { get; set; }

    [Required]
    public string UserName { get; set; }

    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Caste { get; set; }
    public string Occupation { get; set; }
    public Double Salary { get; set; }
    public MaritialStatus MaritialStatus { get; set; }
    public Religion Religion { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string City { get; set; }

    public List<string> Claims { get; set; }

    public IList<string> Roles { get; set; }
}