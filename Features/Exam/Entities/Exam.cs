using ExamOnlineSystem.Features.Categories.Entities;
using ExamOnlineSystem.Features.Questions.Entities;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Exams.Entities
{
    public class Exam : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty!;
        public string IconUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserExam> UserExams { get; set; } = [];
        public ICollection<Question> Questions { get; set; } = [];
    }
}
