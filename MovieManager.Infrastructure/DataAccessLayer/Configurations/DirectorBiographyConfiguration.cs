namespace MovieManager.Infrastructure.DataAccessLayer.Configurations;

public class DirectorBiographyConfiguration : IEntityTypeConfiguration<DirectorBiography>
{
    public void Configure(EntityTypeBuilder<DirectorBiography> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Career).HasMaxLength(300);
        builder.Property(p => p.CityOfBirth).HasMaxLength(150);
        builder.Property(p => p.CountryOfBirth).HasMaxLength(100);
        builder.Property(p => p.Education).HasMaxLength(250);
    }
}