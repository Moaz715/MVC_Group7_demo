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
        (bool, string?) Create(ProductCart productOrder);
        //(bool, string?) Update(int id, int qty);
        (bool, string?) Delete(int id, string deletedBy);
    }
}
