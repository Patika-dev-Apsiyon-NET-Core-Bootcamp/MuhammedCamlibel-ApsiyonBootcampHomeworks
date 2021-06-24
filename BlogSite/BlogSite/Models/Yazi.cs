using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public class Yazi
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string YaziMetni { get; set; }
        public List<Yorum> Yorumlar { get; set; }
        public List<Kategori> Kategoriler { get; set; }

    }
}
