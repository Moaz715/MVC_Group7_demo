using Microsoft.EntityFrameworkCore;
using MVC_Group7_demo_DAL.DataBase;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Implementation
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly Context db;

        public CategoryRepo(Context db)
        {
            this.db = db;
        }

        public async Task<(bool, string?)> CreateAsync(Category category)
        {
            try
            {
                await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> UpdateAsync(int id, string name, string modifiedBy)
        {
            try
            {
                var res = await db.Categories.Where(c => c.CategoryId == id && !c.IsDeleted).FirstOrDefaultAsync();

                if (res == null)
                {
                    return (false, "Category not found in database");
                }

                res.UpdateName(name, modifiedBy);
                await db.SaveChangesAsync();
                return (true, null);
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
                var res = await db.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();

                if (res == null)
                {
                    return (false, "Category not found in database");
                }

                res.Delete(deletedBy);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<Category>?, string?)> GetAllAsync()
        {
            try
            {
                var res = await db.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).ToListAsync();

                if (res == null || res.Count == 0)
                {
                    return (null, "No categories found in database");
                }


                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(Category?, string?)> GetByIdAsync(int id)
        {
            try
            {
                var res = await db.Categories.Include(c => c.Products).Where(c => c.CategoryId == id && !c.IsDeleted).FirstOrDefaultAsync();

                if (res == null)
                {
                    return (null, "Category not found in database");
                }

                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
