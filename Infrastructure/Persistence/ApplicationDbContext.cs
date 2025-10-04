using ExamOnlineSystem.Features.Answer.Entities;
using ExamOnlineSystem.Features.Exams.Entities;
using ExamOnlineSystem.Features.Questions.Entities;
using ExamOnlineSystem.Features.Result.Entities;
using ExamOnlineSystem.Shared.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ExamOnlineSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }


        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<UserSelectedChoice> UserSelectedChoices { get; set; }

    }
}
