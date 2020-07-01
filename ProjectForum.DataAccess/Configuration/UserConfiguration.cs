using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace ProjectForum.EfDataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasAlternateKey(user => user.Username);
            builder.HasIndex(user => user.Email).IsUnique();
            builder.HasIndex(user => user.Username).IsUnique();

            builder.Property(user => user.FirstName).HasMaxLength(30);
            builder.Property(user => user.LastName).HasMaxLength(30);
            builder.Property(user => user.Password).HasMaxLength(30);
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Username).HasMaxLength(30);
            builder.Property(user => user.Username).IsRequired();
            builder.Property(user => user.Email).IsRequired();

            builder.HasMany(user => user.Questions)
                .WithOne(question => question.User)
                .HasForeignKey(question => question.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(user => user.Replies)
                .WithOne(replies => replies.User)
                .HasForeignKey(replies => replies.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
