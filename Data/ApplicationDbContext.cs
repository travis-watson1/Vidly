using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                    new Genre
                    {
                        Id = 1,
                        Name = "Action"
                    }, 
                    new Genre
                    {
                        Id = 2,
                        Name = "Thriller"
                    }, 
                    new Genre
                    {
                        Id = 3,
                        Name = "Family"
                    }, 
                    new Genre
                    {
                        Id = 4,
                        Name = "Romance"
                    }, 
                    new Genre
                    {
                        Id = 5,
                        Name = "Comedy"
                    }
            );

            modelBuilder.Entity<MembershipType>().HasData(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Pay As You Go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },                    
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },                    
                    new MembershipType
                    {
                        Id = 3,
                        Name = "Quarterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },                    
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    }
            );
        }
    }
}
