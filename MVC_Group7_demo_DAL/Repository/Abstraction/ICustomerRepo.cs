using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface ICustomerRepo
    {
        Task<(Customer?, string?)> GetById(string id);
        (List<Customer>?, string?) GetAll();
        Task<(bool, string?)> Create(Customer customer);
        (bool, string?) Update(string id, string name, string modifiedBy);
        (bool, string?) Delete(string id, string deletedBy);
    }
}
