using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class FinalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ExpenseIn> Inbound { get; set; }
        public DbSet<ExpenseOut> Outbound { get; set; }
    }
}