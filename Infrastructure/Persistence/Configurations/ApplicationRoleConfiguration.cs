using ExamOnlineSystem.Shared.Auth;
using ExamOnlineSystem.Shared.Auth.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamOnlineSystem.Infrastructure.Persistence.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(new ApplicationRole
            {
                Id = DefaultRoles.AdminRoleId,
                Name = DefaultRoles.Admin,
                NormalizedName = DefaultRoles.Admin.ToUpper(),
                ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp,

            },
            new ApplicationRole
            {
                Id = DefaultRoles.StudentRoleId,
                Name = DefaultRoles.Student,
                NormalizedName = DefaultRoles.Student.ToUpper(),
                ConcurrencyStamp = DefaultRoles.StudentRoleConcurrencyStamp,
                IsDefault = true
            }

            );
        }
    }
}
