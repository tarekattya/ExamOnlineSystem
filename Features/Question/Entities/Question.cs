using ExamOnlineSystem.Features.Answer.Entities;
using ExamOnlineSystem.Features.Exams.Entities;
using ExamOnlineSystem.Shared;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Questions.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public QuestionType Type { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; } = default!;

        public ICollection<Choice> Choices { get; set; } = [];
        public ICollection<UserAnswer> UserAnswers { get; set; } = [];
    }
}
