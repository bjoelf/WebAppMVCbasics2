using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Database
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        //Easy to forget to set to public!
        public DbSet<Person> People { get; set; }

        //One DBSet for each type/object that go into the db??
    }
}
