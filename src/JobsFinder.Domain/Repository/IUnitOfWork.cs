namespace JobsFinder.Domain.Repository;
public interface IUnitOfWork : IDisposable
{
    Task Commit();
}
