using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface ICategoryRepo
    {
        Task<(bool, string?)> CreateAsync(Category category);
        Task<(bool, string?)> UpdateAsync(int id, string name, string modifiedBy);
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);
        Task<(List<Category>?, string?)> GetAllAsync();
        Task<(Category?, string?)> GetByIdAsync(int id);
        Task<(Category?, string?)> GetByNameAsync(string name);
    }
}
