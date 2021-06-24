using Microsoft.EntityFrameworkCore;
using Odev2.Data.Abstract;
using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Data.Concrete
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantContext _restaurantContext;

        public RestaurantRepository(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public void AddFood(string foodName, int restaurantId)
        {
            var restaurant = _restaurantContext.Restaurants.FirstOrDefault(r => r.Id == restaurantId);
            _restaurantContext.Foods.Add(new Food() { Name = foodName, Restaurant = restaurant });
            _restaurantContext.SaveChanges();
        }

        public void Create(Restaurant entity)
        {
            _restaurantContext.Restaurants.Add(entity);
            _restaurantContext.SaveChanges();
        }

        public void Delete(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetAll()
        {
            return _restaurantContext.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return _restaurantContext.Restaurants.Include(r => r.Foods).Where(r => r.Id == id).FirstOrDefault();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
