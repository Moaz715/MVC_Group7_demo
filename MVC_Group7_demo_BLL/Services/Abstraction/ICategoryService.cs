using MVC_Group7_demo_BLL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<(bool, string?)> CreateAsync(CreateCategoryDto dto);
        Task<(bool, string?)> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);
        Task<(ReadCategoryDto?, string?)> GetByIdAsync(int id);
        Task<(List<ReadCategoryDto>, string?)> GetAllAsync();


    }
}
