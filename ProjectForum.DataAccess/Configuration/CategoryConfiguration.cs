using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectForum.Domain.Entities;

namespace ProjectForum.EfDataAccess.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(category => category.Name).IsUnique();

            builder.Property(category => category.Name).HasMaxLength(30);
            builder.Property(category => category.Name).IsRequired();

            builder.HasMany(category => category.Questions)
                .WithOne(question => question.Category)
                .HasForeignKey(question => question.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
