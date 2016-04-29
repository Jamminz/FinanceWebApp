using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CombinedDbContext : DbContext
    {
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Amount> Amounts { get; set; }
    }
}