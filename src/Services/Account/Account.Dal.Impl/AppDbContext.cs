using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Account.API.Entities;

namespace Account.Dal.Impl
{
    public class AppDbContext : DbContext
    {

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
