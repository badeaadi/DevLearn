using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace TestsData
{
    public class TestsDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
     public TestsDataContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options) { }

        
    }

}
