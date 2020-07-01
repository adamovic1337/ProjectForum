using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectForum.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectForum.EfDataAccess.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(question => question.Title).IsRequired();
            builder.Property(question => question.Body).HasColumnType("text");

            builder.HasMany(question => question.Replies)
                .WithOne(reply => reply.Question)
                .HasForeignKey(reply => reply.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(question => question.QuestionTags)
                .WithOne(questionTag => questionTag.Question)
                .HasForeignKey(questionTag => questionTag.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
