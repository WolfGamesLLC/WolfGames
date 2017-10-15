using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WolfGamesSite.DAL.Models.SimpleGameModels;

namespace WolfGamesSite.DAL.Data
{
    /// <summary>
    /// DB context for the Marble Motion game
    /// </summary>
    public class MarbleMotionDBContext : DbContext
    {
        /// <summary>
        /// The default constructor for the Marble Motion game DB context
        /// </summary>
        /// <param name="options">The context options to use when construction the context</param>
        public MarbleMotionDBContext(DbContextOptions<MarbleMotionDBContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Actions to perform when building the table
        /// </summary>
        /// <param name="builder">The ModelBuilder to use when creating the table</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        /// <summary>
        /// The base DB set of the Marble Motion game
        /// </summary>
        public DbSet<MarbleMotion> MarbleMotionRecords { get; set; }
    }
}
