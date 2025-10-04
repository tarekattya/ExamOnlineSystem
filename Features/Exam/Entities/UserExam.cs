using ExamOnlineSystem.Features.Result.Entities;
using ExamOnlineSystem.Shared.Auth;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Exams.Entities
{
    public class UserExam : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default!;

        public int ExamId { get; set; }
        public Exam Exam { get; set; } = default!;

        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int AttemptNumber { get; set; }

        public ExamResult ExamResult { get; set; } = default!;
        public ICollection<UserAnswer> UserAnswers { get; set; } = [];
    }
}