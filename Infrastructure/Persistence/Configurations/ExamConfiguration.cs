using ExamOnlineSystem.Features.Exams.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.IconUrl).IsRequired();

            builder.Property(e => e.Description)
                     .IsRequired()
                     .HasMaxLength(1000);

            builder.HasOne(e => e.Category)
                   .WithMany(c => c.Exams)
                   .HasForeignKey(e => e.CategoryId);

            builder.HasMany(e => e.UserExams)
                   .WithOne(ue => ue.Exam)
                   .HasForeignKey(ue => ue.ExamId)
                   .OnDelete(DeleteBehavior.Restrict);
            
        }


    }
}