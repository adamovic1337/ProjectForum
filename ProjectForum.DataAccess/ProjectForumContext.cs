using Microsoft.EntityFrameworkCore;
using ProjectForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.EfDataAccess
{
    public class ProjectForumContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.GlobalQueryFilterForIsDeleted();
            modelBuilder.ApplyAllConfigurations();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity entity)
                {
                    switch (entry.State)
                    {                        
                        case EntityState.Added:
                            entity.IsActive = true;
                            entity.CreatedAt = DateTime.Now;
                            entity.IsDeleted = false;
                            entity.ModifiedAt = null;
                            entity.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedAt = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjectForum;Integrated Security=True");
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
        public DbSet<QuestionTag> QuestionTag { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

    }
}
