namespace Application.Shared;

public interface IUnitOfWork
{
    public Task CommitAsync();
}
