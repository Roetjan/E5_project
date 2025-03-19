using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakersMarkt.Classes;
using Microsoft.EntityFrameworkCore;

namespace MakersMarkt
{
    class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                ConfigurationManager.ConnectionStrings["Database"].ConnectionString, ServerVersion.Parse("8.0.13"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "koper" },
                new Role { Id = 2, Name = "maker" },
                new Role { Id = 3, Name = "Admin" }
            );
        }
    }
}
