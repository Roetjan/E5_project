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

            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1, Name="Fiets", Description="fiets"}
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Strawberry Fields Forever", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 2, Name = "Penny Lane", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 3, Name = "Hey Jude", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 4, Name = "Let It Be", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 5, Name = "Yesterday", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 6, Name = "Come Together", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 7, Name = "Something", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 8, Name = "Here Comes the Sun", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 9, Name = "Lucy in the Sky with Diamonds", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 10, Name = "Eleanor Rigby", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 11, Name = "Yellow Submarine", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 12, Name = "A Day in the Life", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 13, Name = "All You Need Is Love", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 14, Name = "I Want to Hold Your Hand", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 15, Name = "While My Guitar Gently Weeps", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 16, Name = "With a Little Help from My Friends", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 17, Name = "Norwegian Wood", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 18, Name = "Blackbird", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 19, Name = "She Loves You", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 20, Name = "Help!", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 21, Name = "Eight Days a Week", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 22, Name = "I Am the Walrus", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 23, Name = "The Long and Winding Road", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 24, Name = "Ticket to Ride", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 25, Name = "Revolution", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 26, Name = "Love Me Do", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 27, Name = "Get Back", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 28, Name = "Ob-La-Di, Ob-La-Da", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 29, Name = "Michelle", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 30, Name = "Drive My Car", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 31, Name = "Do You Want to Know a Secret", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 32, Name = "We Can Work It Out", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 33, Name = "Magical Mystery Tour", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 34, Name = "Paperback Writer", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 35, Name = "Lady Madonna", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 36, Name = "Twist and Shout", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 37, Name = "Back in the U.S.S.R.", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 38, Name = "I Feel Fine", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 39, Name = "Baby, You're a Rich Man", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 40, Name = "And I Love Her", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 41, Name = "If I Fell", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 42, Name = "Rain", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 43, Name = "Across the Universe", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 44, Name = "You Never Give Me Your Money", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 45, Name = "Golden Slumbers", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 46, Name = "She's Leaving Home", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 47, Name = "I Saw Her Standing There", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 48, Name = "Don't Let Me Down", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 49, Name = "Sgt. Pepper's Lonely Hearts Club Band", Description = "", Price = 1.00M, CategoryId = 1 },
new Product { Id = 50, Name = "The Fool on the Hill", Description = "", Price = 1.00M, CategoryId = 1 }

                );

        }
    }
}
