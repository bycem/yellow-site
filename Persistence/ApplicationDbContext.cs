using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerEntityConfig());
            builder.ApplyConfiguration(new PaymentEntityConfig());
            builder.ApplyConfiguration(new OrderEntityConfig());
            builder.ApplyConfiguration(new VehicleListingEntityConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<VehicleListing> VehicleListings { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
