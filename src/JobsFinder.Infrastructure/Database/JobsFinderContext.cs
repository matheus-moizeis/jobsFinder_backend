using JobsFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsFinder.Infrastructure.Database;
public class JobsFinderContext : DbContext
{
    public JobsFinderContext(DbContextOptions<JobsFinderContext> options) : base(options)
    { }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobsFinderContext).Assembly);
    }

    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Estado> Estados { get; set; }
}
