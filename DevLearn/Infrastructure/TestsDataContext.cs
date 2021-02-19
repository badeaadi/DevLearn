using Microsoft.EntityFrameworkCore;

namespace TestsData
{
    public class TestsDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Server=(localdb)\\mssqllocaldb;Database=Tests");
        }
        public TestsDataContext()
        {

        }
        public TestsDataContext(DbContextOptions <TestsDataContext> options)  : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

      
    }
}