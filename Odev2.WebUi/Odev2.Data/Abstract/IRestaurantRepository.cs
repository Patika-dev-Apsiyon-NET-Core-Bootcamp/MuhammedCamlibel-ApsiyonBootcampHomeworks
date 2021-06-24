using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Data.Abstract
{
   public  interface IRestaurantRepository:IRepository<Restaurant>
    {
        void AddFood(string foodName, int restaurantId);
    }
}
