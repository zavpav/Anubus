namespace Anubus.Api.Db;

/// <summary> Фабрика для DbContext </summary>
/// <remarks>
/// Пришлось сделать свою фабрику, потому что для IDbContextFactory требовался DbContext, а я хотел резолвить интерфейсы
/// </remarks>
public interface IDbAnubusContextFactory<T>
        where T : IDisposable
{
    Task<T> CreateDbContextAsync();
}

/// <summary> Фабрика для DbContext </summary>
/// <remarks>
/// Пришлось сделать свою фабрику, потому что для IDbContextFactory требовался DbContext, а я хотел резолвить интерфейсы
/// </remarks>
public class DbAnubusContextFactory<TI, T> : IDbAnubusContextFactory<TI>
    where T : DbContext, TI
    where TI : IDisposable
{
    private readonly IDbContextFactory<T> _dbContextFactory;

    public DbAnubusContextFactory(IDbContextFactory<T> dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
    }

    public async Task<TI> CreateDbContextAsync()
    {
        return await this._dbContextFactory.CreateDbContextAsync();
    }
}
