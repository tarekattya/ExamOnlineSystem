using ExamOnlineSystem.Features.Exams.Entities;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Result.Entities
{
    public class ExamResult : BaseEntity
    {
        public int UserExamId { get; set; }
        public UserExam UserExam { get; set; } = default!;

        public double Score { get; set; }
        public bool IsPassed { get; set; }
        public DateTime GradedAt { get; set; } = DateTime.UtcNow;
    }
}
