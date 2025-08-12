using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Group7_demo_DAL;
using MVC_Group7_demo_DAL.Entities;


namespace MVC_Group7_demo_DAL.DataBase
{
    public class Context : IdentityDbContext<ApplicationUser>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductOrder>()
                .HasIndex(po => new { po.Orderid, po.Productid })
                .IsUnique();

            modelBuilder.Entity<ProductCart>()
                .HasIndex(pc => new { pc.Cartid, pc.Productid })
                .IsUnique();
        }


        public DbSet<Orders> Orders { get; set; }
        
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductOrder> productOrders { get; set; }

        public DbSet<ProductCart> productCarts { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
