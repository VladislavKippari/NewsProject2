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
        }
    }
}
