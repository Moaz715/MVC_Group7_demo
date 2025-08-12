using MVC_Group7_demo_DAL.DataBase;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;


namespace MVC_Group7_demo_DAL.Repository.Implementation
{
    public class DeliveryRepo : IDeliveryRepo
    {
        private readonly Context db;
        public DeliveryRepo(Context db)
        {
            this.db = db;
        }

        public Task<(bool, string?)> CreateAsync(Delivery delivery)
        {
            try
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
                return Task.FromResult<(bool, string?)>((true, null));
            }
            catch (Exception ex)
            {
                return Task.FromResult<(bool, string?)>((false, ex.Message));
            }
        }

        public Task<(Delivery?, string?)> GetByIdAsync(int id)
        {
            try
            {
                var res = db.Deliveries.Where(c => c.Delivery_id == id).FirstOrDefault();

                if (res == null)
                {
                    return Task.FromResult<(Delivery?, string?)>((null, "Delivery not found"));
                }

                return Task.FromResult<(Delivery?, string?)>((res, null));
            }
            catch (Exception ex)
            {
                return Task.FromResult<(Delivery?, string?)>((null, ex.Message));
            }
        }

        public Task<(bool, string?)> UpdateAsync(int id, string name, string modifiedBy)
        {
            var existing = db.Deliveries.Where(c => c.Delivery_id == id).FirstOrDefault();
            if (existing == null)
                return Task.FromResult<(bool, string?)>((false, "Delivery not found"));

            existing.UpdateName(name, modifiedBy);
            db.SaveChanges();
            return Task.FromResult<(bool, string?)>((true, null));
        }

        public Task<(bool, string?)> DeleteAsync(int id, string deletedBy)
        {
            try
            {
                var delivery = db.Deliveries.Where(c => c.Delivery_id == id).FirstOrDefault();
                if (delivery == null)
                    return Task.FromResult<(bool, string?)>((false, "Delivery not found"));

                delivery.Delete(id, deletedBy);
                db.SaveChanges();
                return Task.FromResult<(bool, string?)>((true, null));
            }
            catch (Exception ex)
            {
                return Task.FromResult<(bool, string?)>((false, ex.Message));
            }
        }

        public Task<(List<Delivery>, string?)> GetAllAsync()
        {
            try
            {
                var res = db.Deliveries.Where(c => c.IsDeleted == false).ToList();
                return Task.FromResult<(List<Delivery>, string?)>((res, null));
            }
            catch (Exception ex)
            {
                return Task.FromResult<(List<Delivery>, string?)>((new List<Delivery>(), ex.Message));
            }
        }
    }
}
