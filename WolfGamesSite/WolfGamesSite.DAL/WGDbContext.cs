using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WolfGamesSite.DAL
{
    public class WGDbContext : DbContext
    {
        //public const string DefaultConnection = "DefaultConnection";
        public const string DefaultConnection = @"Data Source = (LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dain\Documents\WolfGames\Repos\WolfGamesSite\WolfGamesSite\App_Data\aspnet-WolfGamesSite-20161112012612.mdf;Initial Catalog = aspnet-WolfGamesSite-20161112012612; Integrated Security = True";
        public WGDbContext() : base(DefaultConnection)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}