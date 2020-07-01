using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.EfDataAccess.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasIndex(country => country.Name).IsUnique();

            builder.Property(country => country.Name).HasMaxLength(60);            
            builder.Property(country => country.Name).IsRequired();

            builder.HasMany(country => country.Users)
                .WithOne(user => user.Country)
                .HasForeignKey(user => user.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
