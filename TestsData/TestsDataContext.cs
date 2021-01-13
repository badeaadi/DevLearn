using Microsoft.EntityFrameworkCore;

namespace TestsData
{
    public class TestsDataContext : DbContext
    {
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