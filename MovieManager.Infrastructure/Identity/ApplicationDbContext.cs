namespace MovieManager.Infrastructure.Identity;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<OperationalStoreOptions> operationalOptions) 
        : base(options, operationalOptions)
    {
        
    }
}