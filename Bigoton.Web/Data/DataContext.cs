using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bigoton.Web.Data.Entities;

namespace Bigoton.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<CutStyle> CutStyles { get; set; }

        public DbSet<DiscountVoucher> DiscountVouchers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}