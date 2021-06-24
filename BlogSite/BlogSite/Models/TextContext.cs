using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public class TextContext : DbContext
    {
        public TextContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Yazi> Yazilar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

    }
}
