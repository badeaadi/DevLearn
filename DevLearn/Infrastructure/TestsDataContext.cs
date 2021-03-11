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
            modelBuilder.Entity<Problem>().HasKey(p => p.IdProblem);

            modelBuilder.Entity<Problem>()
                .HasOne(p => p.ProblemLecture)
                .WithMany(b => b.Problems);

            modelBuilder.Entity<Pupil>()
                .HasIndex(p => p.Username)
                .IsUnique();
        }
        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Slide> Slide { get; set; }

    }
}