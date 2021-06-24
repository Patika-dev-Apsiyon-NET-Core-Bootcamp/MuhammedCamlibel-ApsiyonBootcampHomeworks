using Odev2.Data.Abstract;
using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Data.Concrete
{
    public class FoodRepository : IFoodRepository
    {
        private readonly RestaurantContext _restaurantContext;

        public FoodRepository(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public void Create(Food entity)
        {
            _restaurantContext.Foods.Add(entity);
            _restaurantContext.SaveChanges();
        }

        public void Delete(Food entity)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetAll()
        {
            throw new NotImplementedException();
        }

        public Food GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Food entity)
        {
            throw new NotImplementedException();
        }
    }
}
