using Odev2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2.Business.Abstract
{
    public interface IFoodService
    {
        void Create(Food entity);
        void Update(Food entity);
        void Delete(Food entity);
        List<Food> GetAll();
        Food GetById(int id);
    }
}
