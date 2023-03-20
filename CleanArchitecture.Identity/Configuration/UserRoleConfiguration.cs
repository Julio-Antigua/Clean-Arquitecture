using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "da8d25e0-c366-11ed-afa1-0242ac120002",
                        UserId = "71f7a91c-c364-11ed-afa1-0242ac120002"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "837479f6-c367-11ed-afa1-0242ac120002",
                        UserId = "0d2c2020-c365-11ed-afa1-0242ac120002"
                    }
                );
        }
    }
}
