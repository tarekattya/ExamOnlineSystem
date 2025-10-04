using ExamOnlineSystem.Features.Questions.Entities;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Exams.Entities
{
    public class UserAnswer :BaseEntity
    {
        public int UserExamId { get; set; }
        public UserExam UserExam { get; set; } = default!;

        public int QuestionId { get; set; }
        public Question Question { get; set; } = default!;

        public ICollection<UserSelectedChoice> SelectedChoices { get; set; } = [];
    }
}