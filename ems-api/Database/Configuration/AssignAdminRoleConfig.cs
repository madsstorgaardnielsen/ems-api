using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ems_api.Database.Configuration;

public class AssignAdminRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>> {
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder) {
        var assignRole = new IdentityUserRole<string> {
            RoleId = "-1",
            UserId = "-1"
        };

        builder.HasData(assignRole);
    }
}