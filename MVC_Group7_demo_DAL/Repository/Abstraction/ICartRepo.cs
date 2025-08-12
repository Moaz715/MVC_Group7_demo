using MVC_Group7_demo_DAL.Entities;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface ICartRepo
    {
        Task<(bool, string?)> CreateAsync(Cart cart);

        //Task<(bool, string?)> EditAsync(int id); //Eh el edit ely h3mlo ll cart hwa ya2ma add item ya2ema delete item fa eh el edit?

        Task<(Cart?, string?)> GetByIdAsync(int id);

        Task<(List<Cart>?, string?)> GetAllAsync();

        Task<(bool, string?)> DeleteAsync(int id);
    }
}
