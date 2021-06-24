using Odev2.Business.Abstract;
using Odev2.Data.Abstract;
using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Business.Concrete
{
    public class RestaurantManager : IRestaurantService
    {

        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantManager(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public void AddFood(string foodName, int restaurantId)
        {
            _restaurantRepository.AddFood(foodName, restaurantId);
        }

        public void Create(Restaurant entity)
        {
            _restaurantRepository.Create(entity);
        }

        public void Delete(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }

        public Restaurant GetById(int id)
        {
            return _restaurantRepository.GetById(id);
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
