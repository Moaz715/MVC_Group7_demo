using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IProductCartRepo
    {
        (List<ProductCart>?, string?) GetAll();
        (ProductCart?, string?) GetById(int id);
        public Task<(bool, string?)> Create(ProductCart productCart);
        //(bool, string?) Update(int id, int qty);
        public Task<(bool, string?)> Delete(int id, string deletedBy);
        public Task<(bool, string?)> Reactivate(int id);
    }
}
