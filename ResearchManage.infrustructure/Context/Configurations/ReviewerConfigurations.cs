using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResearchManage.Domain.Entities;


namespace ResearchManage.Infrustructure.Context.Configurations
{
    public class ReviewerConfigurations : IEntityTypeConfiguration<Reviewer>
    {
        public void Configure(EntityTypeBuilder<Reviewer> builder)
        {
            builder.ToTable("Reviewers");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(200);

            builder.HasMany(r=>r.Comments).WithOne(c=>c.reviewer)
                .HasForeignKey(c=>c.ReviewerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
