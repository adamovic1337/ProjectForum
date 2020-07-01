using Microsoft.EntityFrameworkCore;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.EfDataAccess
{
    public static class DataAccessExtensions
    {
        public static void GlobalQueryFilterForIsDeleted(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasQueryFilter(country => !country.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(user => !user.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(role => !role.IsDeleted);
            modelBuilder.Entity<Question>().HasQueryFilter(question => !question.IsDeleted);
            modelBuilder.Entity<Reply>().HasQueryFilter(reply => !reply.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(category => !category.IsDeleted);
            modelBuilder.Entity<Tag>().HasQueryFilter(tag => !tag.IsDeleted);
        }

        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ReplyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.Entity<QuestionTag>().HasKey(questionTag => new { questionTag.QuestionId, questionTag.TagId });
            modelBuilder.Entity<UseCaseLog>().Property(ucl => ucl.Data).HasColumnType("text"); ;
        }
    }
}
