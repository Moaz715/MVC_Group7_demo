using MVC_Group7_demo_BLL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface IProductService
    {


        Task<(bool, string?)> CreateAsync(CreateProductDto dto);
        Task<(bool, string?)> UpdateAsync(int id, UpdateProductDto dto);
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);
        Task<(ReadProductDto?, string?)> GetByIdAsync(int id);
        Task<(List<ReadProductDto>?, string?)> GetAllAsync(bool isAdmin = false);
        Task<(List<ReadProductDto>?, string?)> GetByCategoryIdAsync(int categoryId, bool isAdmin = false);

        Task<(List<ReadProductDto>?, string?)> SearchByNameAsync(string name, bool isAdmin = false);
        Task<(bool, string?)> IncreaseStockAsync(int productId, int amount, string modifiedBy);
        Task<(bool, string?)> DecreaseStockAsync(int productId, int amount, string modifiedBy);
        Task<(bool, string?)> UpdateStockAsync(int productId, int newStock, string modifiedBy);
        Task<(bool, string?)> CheckStockAsync(int productId, int quantity);





    }
}
