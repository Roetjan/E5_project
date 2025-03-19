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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                ConfigurationManager.ConnectionStrings["Database"].ConnectionString, ServerVersion.Parse("8.0.13"));
        }
    }
}
