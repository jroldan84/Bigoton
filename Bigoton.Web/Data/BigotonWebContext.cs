using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bigoton.Web.Data.Entities;

namespace Bigoton.Web.Models
{
    public class BigotonWebContext : DbContext
    {
        public BigotonWebContext (DbContextOptions<BigotonWebContext> options)
            : base(options)
        {
        }

        public DbSet<Bigoton.Web.Data.Entities.Client> Client { get; set; }
    }
}
