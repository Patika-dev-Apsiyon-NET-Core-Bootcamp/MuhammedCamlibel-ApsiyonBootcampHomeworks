using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Yazi Yazi { get; set; }
        public string YorumMetni { get; set; }

    }
}
