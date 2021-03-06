﻿using Microsoft.EntityFrameworkCore;
using NewsApp.Domain.Entities;
using NewsApp.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence
{
  
    public class NewsAppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

       
        string startupPath = Environment.CurrentDirectory;
        public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options) : base(options)
        { }
        public NewsAppDbContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewsAppDB;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Article);
       
            modelBuilder.Entity<Article>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Articles);
            modelBuilder.Entity<User>()
              .HasMany(c => c.Comments)
              .WithOne(c => c.User);
            modelBuilder.Entity<User>()
          .HasMany(c => c.Articles)
          .WithOne(c => c.Journalist);
            modelBuilder.Entity<Role>()
              .HasMany(r => r.Users)
              .WithOne(r => r.Role);
           
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Users);
            //Configuration : IEntityTypeConfiguration
            
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
         
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.SeedData();

        }

    }
}
