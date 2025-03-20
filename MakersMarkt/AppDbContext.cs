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
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ReviewUser> ReviewUsers { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<ProductPortfolio> ProductPortfolios { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                ConfigurationManager.ConnectionStrings["Database"].ConnectionString, ServerVersion.Parse("8.0.13"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReviewUser>().HasKey(ru => new { ru.ReviewId, ru.UserId });
            modelBuilder.Entity<NotificationUser>().HasKey(nu => new { nu.NotificationId, nu.UserId });
            modelBuilder.Entity<ProductPortfolio>().HasKey(pp => new { pp.Portfolio_id, pp.Product_id });
            modelBuilder.Entity<ProductReview>().HasKey(pr => new { pr.ReviewId, pr.ProductId });
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            // Relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReviewUsers)
                .WithOne(ru => ru.User)
                .HasForeignKey(ru => ru.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.NotificationUsers)
                .WithOne(nu => nu.User)
                .HasForeignKey(nu => nu.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne()
                .HasForeignKey<Order>(o => o.PaymentId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "koper" },
                new Role { Id = 2, Name = "maker" },
                new Role { Id = 3, Name = "Admin" }
            );
        }
    }
}
