using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WolfGamesSite.Models
{
    public class WGDbContext : DbContext
    {
        public const string DefaultConnection = "DefaultConnection";
        public WGDbContext() : base(DefaultConnection)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}