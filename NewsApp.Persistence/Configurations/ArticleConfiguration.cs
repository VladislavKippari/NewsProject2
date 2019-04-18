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
        }
    }
}
