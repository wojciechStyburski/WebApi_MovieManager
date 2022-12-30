namespace MovieManager.Infrastructure.DataAccessLayer.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .OwnsOne(p => p.DirectorName)
            .Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();

        builder
            .OwnsOne(p => p.DirectorName)
            .Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
    }
}