using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepo cartRepo;

        public CartServices(ICartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }

        public (bool, string) Create(CartDTO cartDTO)
        {
            throw new NotImplementedException();
        }

        public (bool, string) Create()
        {
            throw new NotImplementedException();
        }

        public (bool, string) Delete(int id)
        {
            throw new NotImplementedException();
        }

        public (bool, string) Edit()
        {
            throw new NotImplementedException();
        }

        public (List<Cart>, string?) GetAll()
        {
            throw new NotImplementedException();
        }

        public (Cart, string) GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
