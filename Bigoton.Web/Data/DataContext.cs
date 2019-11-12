



using Bigoton.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bigoton.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<CutStyle> CutStyles { get; set; }

        public DbSet<DiscountVoucher> DiscountVouchers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
      
    }
}