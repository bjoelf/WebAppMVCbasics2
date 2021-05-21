using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMVCbasics2app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAppMVCbasics2app.Database
{
    public class PeopleDbContext : IdentityDbContext<AppUser> 
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
            new
            {
                pl.PersonId,
                pl.LanguageId
            });

            modelBuilder.Entity<PersonLanguage>()
           .HasOne<Person>(x => x.Person)
           .WithMany(p => p.PersonLanguage)
           .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonLanguage>()
           .HasOne<Language>(pl => pl.Language)
           .WithMany(l => l.PersonLanguage)
           .HasForeignKey(pl => pl.LanguageId);
        }

        //Easy to forget to set to public!
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
    }

    ///Kommandon i PM:
    /// REBUILD
    /// dotnet ef migrations add COMMENT
    /// REBUILD
    /// dotnet ef database update
    /// DONE!

}


