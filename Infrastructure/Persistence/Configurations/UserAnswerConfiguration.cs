using ExamOnlineSystem.Features.Exams.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{
    public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
    {
        public void Configure(EntityTypeBuilder<UserAnswer> builder)
        {
            builder.HasKey(ua => ua.Id);

            builder.HasOne(ua => ua.UserExam)
                   .WithMany(ue => ue.UserAnswers)
                   .HasForeignKey(ua => ua.UserExamId).OnDelete(DeleteBehavior.Restrict);
            

            builder.HasOne(ua => ua.Question)
                   .WithMany(q => q.UserAnswers)
                   .HasForeignKey(ua => ua.QuestionId)
                                      .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
