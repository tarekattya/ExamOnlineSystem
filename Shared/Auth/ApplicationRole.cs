using Microsoft.AspNetCore.Identity;

namespace ExamOnlineSystem.Shared.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}
