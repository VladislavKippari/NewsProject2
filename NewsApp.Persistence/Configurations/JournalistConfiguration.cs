using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence.Configurations
{
 
    public class JournalistConfiguration : IEntityTypeConfiguration<Journalist>
    {
        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder.HasKey(e => e.JournalistId);
            builder.Property(u => u.JournalistId).ValueGeneratedOnAdd();
            builder.Property(e => e.Login).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Lastname).HasMaxLength(50);

            builder.ToTable("Journalist");
        }
    }
}
