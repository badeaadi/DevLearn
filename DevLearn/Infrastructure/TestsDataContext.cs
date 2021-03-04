using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestsData
{
    public class TestsDataContext : DbContext
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public TestsDataContext() : base()
        {

        }
        public TestsDataContext(DbContextOptions <TestsDataContext> options)  : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Author> Author { get; set; }
        public DbSet<Slide> Slide { get; set; }

        public DbSet<Variant> Variants { get; set; }
    }
}