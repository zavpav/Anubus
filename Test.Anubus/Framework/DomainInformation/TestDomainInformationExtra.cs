using Anubus.Api.Db;
using Microsoft.EntityFrameworkCore;

namespace TestConsoleTest.DomainInformation;

partial class TestDomainInformation
{
    /// <summary> Информация по домену </summary>
    public class TestDomainDescription<T> : ITestDomainDescription
        where T : class, new()
    {
        public TestDomainDescription(
            string rusName,
            Func<IEnumerable<DomainPropertyInfo>> getAllPropertiesInfo,
            IRepository repository)
        {
            this.DomainType = typeof(T);
            this._getAllPropertiesInfo = getAllPropertiesInfo;
            this.RusName = rusName;
            this.Repository = repository;
        }

        /// <summary> Русское наименование домена </summary>
        public string RusName { get; }

        /// <summary> Доменных тип </summary>
        public Type DomainType { get; }

        /// <summary> Url списка </summary>
        public string? ClientListUrl { get; set; }

        /// <summary> Ссылка на репозитарий </summary>
        public IRepository Repository { get; set; }


        private Func<IEnumerable<DomainPropertyInfo>> _getAllPropertiesInfo;

        /// <summary> Список всех свойств. В качестве ключа - русское имя в нижнем регистре </summary>
        private Dictionary<string, DomainPropertyInfo> _propertiesCache = new Dictionary<string, DomainPropertyInfo>(); 


        public IEnumerable<DomainPropertyInfo> AllPropertiesInfo()
        {
            if (this._propertiesCache.Count == 0)
                this._propertiesCache = this._getAllPropertiesInfo().ToDictionary(x => x.Name.ToLower(), x => x);
            return this._propertiesCache.Values;
        }

        public DomainPropertyInfo PropertyInfo(string rusPropertyName)
        {
            if (this._propertiesCache.Count == 0)
                this._propertiesCache = this._getAllPropertiesInfo().ToDictionary(x => x.Name.ToLower(), x => x);

            try
            {
                var l = rusPropertyName.ToLower();
                return this._propertiesCache[l];
            }
            catch (Exception)
            {
                try
                {
                    // Я не понял почему иногда рубится
                    return this._propertiesCache[rusPropertyName.ToLower()];
                }
                catch(Exception ee)
                {
                    Log.Default.Error(ee, "Ошибка поиска свойства '{PropertyName}' для сущности '{DomainName}'. Список найденных свойств {@PropertyList}", rusPropertyName, this.RusName, this.AllPropertiesInfo().Select(x => x.Name).ToArray());

                    throw new TestException("Ошибка поиска свойства '{0}' для сущности '{1}'", rusPropertyName, this.RusName);
                }
            }
        }

        /// <summary> Создать простой доменный объект </summary>
        /// <returns></returns>
        public object CreateDomain()
        {
            return new T();
        }
    }

    /// <summary> Прокладка-репозиторий (получение/сохранение данных напрямую в DbSet) </summary>
    public interface IRepository
    {
        /// <summary> Все нетипизированные записи </summary>
        IEnumerable<object> AllEntities();

        /// <summary> Количество записей в таблице </summary>
        int Count();

        /// <summary>Сохранить нетепизированную запись </summary>
        void UntypedSave(object domain);
    }

    /// <summary> Прокладка-репозиторий (получение/сохранение данных напрямую в DbSet) </summary>
    public class RepositoryProxy<TDbContext, TDomain> : IRepository
        where TDbContext: DbContext
        where TDomain : class
    {
        private readonly IDbContextFactory<TDbContext> dbContextFactory;
        private readonly Func<TDbContext, DbSet<TDomain>> getDbSet;

        public RepositoryProxy(
                IDbContextFactory<TDbContext> dbContextFactory,
                Func<TDbContext, DbSet<TDomain>> getDbSet)
        {
            this.dbContextFactory = dbContextFactory;
            this.getDbSet = getDbSet;
        }

        public IEnumerable<object> AllEntities()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var dbSet = getDbSet(dbContext);
            return dbSet.ToArray();
        }

        public int Count()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var dbSet = getDbSet(dbContext);
            return dbSet.Count();
        }

        public void UntypedSave(object domain)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var dbSet = getDbSet(dbContext);
            dbSet.Add((TDomain)domain);
            dbContext.SaveChanges();
        }
    }

    /// <summary> Создать DomainInfo с доступом из AnubusContext </summary>
    /// <typeparam name="TDomain">Домен</typeparam>
    /// <param name="rusName">Русское наименование</param>
    /// <param name="getDbSet">Функция получения DbSet</param>
    /// <returns></returns>
    private ITestDomainDescription CreateDomainInfoFromAnubusApi<TDomain>(string rusName, Func<AnubusContext, DbSet<TDomain>> getDbSet)
        where TDomain: class, new()
    {
        var anubusDbContextFactory = Locator.Resolve<IDbContextFactory<AnubusContext>>();

        return new TestDomainDescription<TDomain>(rusName,
                            () => this.GetAllProperties(rusName),
            new RepositoryProxy<AnubusContext, TDomain>(
                            anubusDbContextFactory,
                            getDbSet));
    }
}