using ExamOnlineSystem.Features.Exams.Entities;
using ExamOnlineSystem.Features.Questions.Entities;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Answer.Entities
{
    public class Choice : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; } = default!;

        public ICollection<UserSelectedChoice> UserSelectedChoices { get; set; } = [];
    }
}
