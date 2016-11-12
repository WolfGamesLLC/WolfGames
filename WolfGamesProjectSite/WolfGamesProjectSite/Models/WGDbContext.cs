using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WolfGamesProjectSite.Models
{
    public class WGDbContext : DbContext
    {
        public WGDbContext() : base("DefaultConnection")
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}