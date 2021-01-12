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



    }
}