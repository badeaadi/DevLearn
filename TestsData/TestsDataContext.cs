using System;
using System.ComponentModel;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace TestsData
{
    public class TestsDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TestsDataContext(DbContextOptions<TestsDataContext> options) : base(options)
        {
            Database.SetInitializer<TestsDataContext>(new CreateDatabaseIfNotExists<TestsDataContext>());

        }
        public DbSet<Item> Items {get;set;}
        public DbSet<Lecture> Lectures {get;set;}

        public class Initp : DropCreateDatabaseIfModelChanges<DbContextOptions>
        { // custom initializer
            protected override void Seed(DbCtx ctx)
            {
                Film film = new Film { Denumire = "film" };
                ctx.Filme.Add(film);
                ctx.Recenzii.Add(new Items { Titlu = "Titlu1", Descriere = "Descriere1", Nota = 2, NumeUtilizator = "Utilizator1", Film = film });
                ctx.Recenzii.Add(new Lectures { Titlu = "Titlu2", Descriere = "Descriere2", Nota = 3, NumeUtilizator = "Utilizator2", Film = film });
                ctx.SaveChanges();
                base.Seed(ctx);
            }
        }

    }

}
