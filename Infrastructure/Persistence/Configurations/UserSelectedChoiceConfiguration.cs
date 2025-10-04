using ExamOnlineSystem.Features.Exams.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{
    public class UserSelectedChoiceConfiguration : IEntityTypeConfiguration<UserSelectedChoice>
    {
        public void Configure(EntityTypeBuilder<UserSelectedChoice> builder)
        {
            builder.HasKey(usc => usc.Id);

            builder.HasOne(usc => usc.UserAnswer)
                   .WithMany(ua => ua.SelectedChoices)
                   .HasForeignKey(usc => usc.UserAnswerId).OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(usc => usc.Choice)
                   .WithMany(c => c.UserSelectedChoices)
                   .HasForeignKey(usc => usc.ChoiceId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
