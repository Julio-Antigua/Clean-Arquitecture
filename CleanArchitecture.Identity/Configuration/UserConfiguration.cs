using CleanArquitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "71f7a91c-c364-11ed-afa1-0242ac120002",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "admin@localhost.com",
                        Name = "Vaxi",
                        Lastname = "Drez",
                        UserName = "vaxidrez",
                        NormalizedUserName = "vaxidrez",
                        PasswordHash = hasher.HashPassword(null,"Abc123"),
                        EmailConfirmed = true,
                    },
                     new ApplicationUser
                     {
                         Id = "0d2c2020-c365-11ed-afa1-0242ac120002",
                         Email = "juanperez@localhost.com",
                         NormalizedEmail = "juanperez@localhost.com",
                         Name = "Juan",
                         Lastname = "Perez",
                         UserName = "juanperez",
                         NormalizedUserName = "juanperez",
                         PasswordHash = hasher.HashPassword(null, "Abc123"),
                         EmailConfirmed = true,
                     }
                );
        }
    }
}
