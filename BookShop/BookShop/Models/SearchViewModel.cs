using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class SearchViewModel
    {   [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
