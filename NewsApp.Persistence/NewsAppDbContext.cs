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
        public DbSet<Journalist> Journalists { get; set; }
        public DbSet<User> Users { get; set; }
        public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=NewsAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //one to many
            modelBuilder.Entity<Article>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Article);
            modelBuilder.Entity<Article>()
               .HasMany(c => c.Categorys)
               .WithOne(c => c.Article);
            modelBuilder.Entity<User>()
              .HasMany(c => c.Comments)
              .WithOne(c => c.User);
            modelBuilder.Entity<Article>()
               .HasOne(b => b.Journalist)
               .WithMany(b => b.Articles);



            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new JournalistConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
           

        }

    }
}