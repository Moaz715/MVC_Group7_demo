using MVC_Group7_demo_BLL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface IAdminServices
    {
        Task<(bool, string?)> CreateAsync(AdminDTO adminDTO);
        Task<(AdminDTO?, string?)> GetByIdAsync(string id);
        Task<(List<AdminDTO>?, string?)> GetAllAsync();
        Task<(bool, string?)> UpdateAsync(string id, string name, string modifiedBy);
        Task<(bool, string?)> DeleteAsync(string id, string deletedBy);
    }
} 