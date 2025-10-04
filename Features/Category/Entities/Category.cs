using ExamOnlineSystem.Features.Exams.Entities;
using ExamOnlineSystem.Shared.Entites;

namespace ExamOnlineSystem.Features.Categories.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string IconUrl { get; set; } = string.Empty!;

        public ICollection<Exam> Exams { get; set; } = [];
    }
}
