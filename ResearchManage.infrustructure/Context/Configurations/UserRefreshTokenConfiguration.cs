using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResearchManage.Domain.Entities.Identity;

namespace ResearchManage.Infrustructure.Context.Configurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(u => u.Id);


            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRefreshTokens)
                .HasForeignKey(u => u.userID);

            builder.ToTable("UserRefreshTokens");
        }
    }
}
