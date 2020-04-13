using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonialProject.ViewModels
{
    public class SearchViewModel
    {
        public int Selected { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
