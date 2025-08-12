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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<(bool, string?)> CreateAsync(CreateCategoryDto dto)
        {
            try
            {
                var category = new Category(dto.Name, dto.CreatedBy);
                return await categoryRepo.CreateAsync(category);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<ReadCategoryDto>, string?)> GetAllAsync()
        {
            var (categories, error) = await categoryRepo.GetAllAsync();
            if (categories == null)
                return (new List<ReadCategoryDto>(), error);

            var dtoList = categories.Select(c => new ReadCategoryDto
            {
                Name = c.Name,
                Products = c.Products.Select(p => p.Name).ToList()
            }).ToList();

            return (dtoList, null);
        }

        public async Task<(ReadCategoryDto?, string?)> GetByIdAsync(int id)
        {
            var (category, error) = await categoryRepo.GetByIdAsync(id);
            if (category == null)
                return (null, error);

            var dto = new ReadCategoryDto
            {
                Name = category.Name,
                Products = category.Products.Select(p => p.Name).ToList()
            };

            return (dto, null);
        }

        public async Task<(bool, string?)> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            try
            {
                return await categoryRepo.UpdateAsync(id, dto.Name, dto.ModifiedBy);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> DeleteAsync(int id, string deletedBy)
        {
            try
            {
                return await categoryRepo.DeleteAsync(id, deletedBy);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
