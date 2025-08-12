using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface ICartServices
    {
        (bool, string) Create();

        (bool, string) Edit();

        (Cart, string) GetById(int id);

        (List<Cart>, string?) GetAll();

        (bool, string) Delete(int id);
    }
}
