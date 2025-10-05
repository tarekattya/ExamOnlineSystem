using ExamOnlineSystem.Shared.Auth;
using ExamOnlineSystem.Shared.Auth.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
           builder.HasData(new IdentityUserRole<string>
            {
                RoleId = DefaultRoles.AdminRoleId,
                UserId = DefaultUsers.AdminId
            });
        }
    }
}
