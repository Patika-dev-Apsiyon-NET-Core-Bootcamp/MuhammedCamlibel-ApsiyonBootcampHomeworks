using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BookViewModel
    {   [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
