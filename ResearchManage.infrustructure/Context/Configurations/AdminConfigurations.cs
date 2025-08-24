using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResearchManage.Domain.Entities;


namespace ResearchManage.Infrustructure.Context.Configurations
{
    public class AdminConfigurations : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(200);
        }
    }
}
