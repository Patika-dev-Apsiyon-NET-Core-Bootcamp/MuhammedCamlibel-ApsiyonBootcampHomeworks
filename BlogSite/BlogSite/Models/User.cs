using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthdayYear { get; set; }
        public List<Yazi> Yazilar { get; set; }
        public List<Yorum> Yorumlar { get; set; }

    }
}
