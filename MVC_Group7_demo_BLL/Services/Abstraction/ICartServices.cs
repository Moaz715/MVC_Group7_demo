using MVC_Group7_demo_BLL.ModelVM;
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

        public Task<(bool, string?)> AddProductToCartAsync(int id, string customerId);

        public Task<(bool, string?)> Delete(int id);
        (bool, string) Create();

        (bool, string) Edit();

        (Cart, string) GetById(int id);

        (List<Cart>, string?) GetAll();

        public Task<(bool, string?)> RemoveProductCart(int id);

        public Task<(CartDTO?, string?)> GetCart(string customerId);



    }
}
