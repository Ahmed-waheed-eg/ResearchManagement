using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResearchManage.Domain.Entities;


namespace ResearchManage.Infrustructure.Context.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).IsRequired()
                .HasMaxLength(200);
            
            builder.HasOne(c=>c.research).WithMany(x=>x.comments)
                .HasForeignKey(x=>x.ResearchId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.reviewer).WithMany(x => x.Comments)
                .HasForeignKey(x => x.ReviewerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
