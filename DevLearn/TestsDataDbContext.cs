using Microsoft.EntityFrameworkCore;
using TestsData;

namespace DevLearn
{
    internal class TestsDataDbContext : DbContext
    {
           public TestsDataDbContext()
        {

        }
        public TestsDataDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Author> author { get; set; }
        // gettere si setere aici 

        //    public virtual DbSet<powerUser> Books { get; set; }

    }
}