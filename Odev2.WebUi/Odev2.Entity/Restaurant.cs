using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Entity
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public List<Food> Foods { get; set; }
        public int Star { get; set; }
        public string Address { get; set; }

    }
}
