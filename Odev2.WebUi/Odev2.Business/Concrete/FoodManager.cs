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
    public class FoodManager : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodManager(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public void Create(Food entity)
        {
            _foodRepository.Create(entity);
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
