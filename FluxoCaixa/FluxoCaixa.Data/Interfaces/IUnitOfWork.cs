namespace FluxoCaixa.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        FluxoContext Context { get; }
        public Task SaveChangesAsync();
    }
}
