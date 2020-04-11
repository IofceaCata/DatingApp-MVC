using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.Models
{
    public class Description
    {
        [Key]
        public string DescriptionId { get; set; }
        public string Content { get; set; }
        public ApplicationUser UserId { get; set; }
    }
}
