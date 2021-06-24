using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public List<Yazi> Yazilar { get; set; }
    }
}
