using Microsoft.EntityFrameworkCore;
using System;
using TestApi.Models;

namespace TestApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Company>().ToTable("companies");
        }
    }
}
