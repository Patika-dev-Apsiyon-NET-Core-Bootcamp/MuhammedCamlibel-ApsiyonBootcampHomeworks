using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Odev2.Entity
{
    public class Food
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Name { get; set; }


    }
}
