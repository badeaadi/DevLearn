using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using DevLearn.Models;


namespace DevLearn.DatabaseContext
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
            modelBuilder.Entity<Problem>()
                .HasKey(p => p.IdProblem);

            modelBuilder.Entity<Pupil>()
                .HasIndex(p => p.Username)
                .IsUnique();

            modelBuilder.Entity<Lecture>()
                .HasMany(l => l.Slides);

        }
        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Slide> Slides { get; set; }

        public DbSet<Pupil> Pupils { get; set; }

        public DbSet<Problem> Problems { get; set; }

    }
}