using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IProductRepo
    {
        Task<(bool, string?)> CreateAsync(Product product);
        Task<(bool, string?)> UpdateAsync(int id, string name, double price, string image, int stock, string desc, int categoryId, string modifiedBy);
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);
        Task<(List<Product>?, string?)> GetAllAsync();
        Task<(Product?, string?)> GetByIdAsync(int id);
        Task<(List<Product>, string?)> GetByCategoryIdAsync(int categoryId);
        Task<(List<Product>?, string?)> SearchByNameAsync(string name);
        Task<(bool, string?)> UpdateStockAsync(int productId, int newStock, string modifiedBy);
        Task<(bool, string?)> CheckStockAsync(int productId, int quantity);



    }
}
