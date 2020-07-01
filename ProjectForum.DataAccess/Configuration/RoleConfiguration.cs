using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.EfDataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(role => role.Name).IsUnique();

            builder.Property(role => role.Name).HasMaxLength(20);
            builder.Property(role => role.Name).IsRequired();

            builder.HasMany(role => role.Users)
                .WithOne(user => user.Role)
                .HasForeignKey(user => user.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(role => role.RoleUseCases)
                .WithOne(roleUseCase => roleUseCase.Role)
                .HasForeignKey(roleUseCase => roleUseCase.RoleId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}
