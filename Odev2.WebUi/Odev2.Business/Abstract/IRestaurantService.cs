using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Business.Abstract
{
    public interface IRestaurantService
    {
        void Create(Restaurant entity);
        void Update(Restaurant entity);
        void Delete(Restaurant entity);
        List<Restaurant> GetAll();
        Restaurant GetById(int id);
        void AddFood(string foodName, int restaurantId);
    }
}
