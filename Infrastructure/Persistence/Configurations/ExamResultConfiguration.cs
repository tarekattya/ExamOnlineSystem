using ExamOnlineSystem.Features.Result.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{
    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.HasKey(er => er.Id);

            builder.HasOne(er => er.UserExam)
                   .WithOne(ue => ue.ExamResult)
                   .HasForeignKey<ExamResult>(er => er.UserExamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

