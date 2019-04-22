using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence.Configurations
{
    
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.CommentId);
            builder.Property(u => u.CommentId).ValueGeneratedOnAdd();
            builder.Property(e => e.CommentText).IsRequired().HasMaxLength(255);

            builder.ToTable("Comment");
        }
    }
}
