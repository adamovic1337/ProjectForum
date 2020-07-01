using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectForum.Domain.Entities;

namespace ProjectForum.EfDataAccess.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(tag => tag.Name).IsUnique();

            builder.Property(tag => tag.Name).HasMaxLength(15);
            builder.Property(tag => tag.Name).IsRequired();

            builder.HasMany(tag => tag.TagQuestions)
                .WithOne(questionTag => questionTag.Tag)
                .HasForeignKey(questionTag => questionTag.TagId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
