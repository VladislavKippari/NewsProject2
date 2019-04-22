using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence.Configurations
{
  
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            builder.Property(e => e.Login).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(20);

            builder.ToTable("User");
        }
    }
}
