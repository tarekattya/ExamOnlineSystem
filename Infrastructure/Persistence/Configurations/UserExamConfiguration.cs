using ExamOnlineSystem.Features.Exams.Entities;
using ExamOnlineSystem.Features.Result.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{
    public class UserExamConfiguration : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.HasKey(ue => ue.Id);

            builder.HasOne(ue => ue.Exam)
                   .WithMany(e => e.UserExams)
                   .HasForeignKey(ue => ue.ExamId);

            builder.HasOne(ue => ue.ExamResult)
                   .WithOne(er => er.UserExam)
                   .HasForeignKey<ExamResult>(er => er.UserExamId)
                                      .OnDelete(DeleteBehavior.Restrict);
            

            builder.HasOne(ue => ue.User)
           .WithMany()
           .HasForeignKey(ue => ue.UserId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Restrict)

            ;

        }
    }
}
