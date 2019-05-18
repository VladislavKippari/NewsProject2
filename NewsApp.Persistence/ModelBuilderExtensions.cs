using Microsoft.EntityFrameworkCore;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence
{
   public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new { RoleId = 1, RoleName = "Admin" },
                new { RoleId = 2, RoleName = "User" },
            new { RoleId = 3, RoleName = "Journalist" });
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 1,
                FirstName = "Petr",
                LastName = "Petrov",
                Email = "admin@test.com",
                Password = PasswordGenerate.HashPassword("Admin-12345"),
                RoleId = 1
            });
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 2,
                FirstName = "Anna",
                LastName = "Petrova",
                Email = "user1@test.com",
                Password = PasswordGenerate.HashPassword("User1-12345"),
                RoleId = 2
            });
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 3,
                FirstName = "Jour",
                LastName = "Journalist",
                Email = "journalist1@test.com",
                Password = PasswordGenerate.HashPassword("Journalist1-12345"),
                RoleId = 3
            });

        }
    }
}
