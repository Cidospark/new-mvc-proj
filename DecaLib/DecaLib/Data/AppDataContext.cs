using System;
using DecaLib.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DecaLib.Data
{
    public class AppDataContext : IdentityDbContext<User>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options): base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Photo> Photos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
