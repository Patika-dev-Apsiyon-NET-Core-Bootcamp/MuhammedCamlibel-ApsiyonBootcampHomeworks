using Microsoft.EntityFrameworkCore;
using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Data.Concrete
{
    public class RestaurantContext :DbContext
    {
        public RestaurantContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
