using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.ArticleId);
            builder.Property(u => u.ArticleId).ValueGeneratedOnAdd();
            builder.Property(e => e.Title).HasMaxLength(100);
            builder.Property(e => e.CreatingDate).HasDefaultValueSql("getdate()");
            builder.Property(e => e.ArticleText);
            builder.Property(e => e.Image).HasMaxLength(100);

            builder.ToTable("Article");
        }
    }
}
