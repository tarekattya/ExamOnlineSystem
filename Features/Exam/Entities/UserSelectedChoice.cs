using ExamOnlineSystem.Features.Answer.Entities;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Exams.Entities
{
    public class UserSelectedChoice : BaseEntity
    {
        public int UserAnswerId { get; set; }
        public UserAnswer UserAnswer { get; set; } = default!;

        public int ChoiceId { get; set; }
        public Choice Choice { get; set; } = default!;
    }
}