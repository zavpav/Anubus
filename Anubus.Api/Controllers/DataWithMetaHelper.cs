using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Anubus.Api.Controllers;

public static class DataWithMetaHelper
{
    /// <summary> Дополнить объект с данными метаданными </summary>
    /// <typeparam name="T">Тип объекта (DTO)</typeparam>
    /// <param name="entity">Сущность</param>
    /// <returns>Сущность с информацией</returns>
    public static async Task<DataWithMeta<T>> ReturnWithMeta<T>(T? entity)
        where T : class
    {
        var res = new DataWithMeta<T>(entity);
        var metaMain = await GetMetainformationForType<T>();
        res.Meta.Add(typeof(T).FullName ?? typeof(T).Name, metaMain);

        return res;
    }

    /// <summary> Дополнить объект с данными метаданными </summary>
    /// <typeparam name="T">Тип объекта (DTO)</typeparam>
    /// <typeparam name="U">Тип строк объекта (DTO)</typeparam>
    /// <param name="entity">Сущность</param>
    /// <param name="childs">Функция получения дочерних элементов</param>
    /// <returns>Сущность с информацией</returns>
    public static async Task<DataWithMeta<T>> ReturnWithMeta<T, U>(T? entity, Func<T, IEnumerable<U>> childs)
        where T : class
        where U : class
    {
        //(функции дублируются для количества дочерних элементов)

        var res = new DataWithMeta<T>(entity);
        var metaMain = await GetMetainformationForType<T>();
        res.Meta.Add(typeof(T).FullName ?? typeof(T).Name, metaMain);

        var childMain = await GetMetainformationForType<U>();
        res.Meta.Add(typeof(U).FullName ?? typeof(U).Name, childMain);

        return res;
    }


    private static Task<List<MetaInformation>> GetMetainformationForType<T>()
    {
        var res = new List<MetaInformation>();

        foreach (var pi in typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
        {
            var meta = new MetaInformation(pi.Name);

            if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                meta.Type = "date";
            else if (pi.PropertyType == typeof(string))
                meta.Type = "string";
            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(long?))
                meta.Type = "int";
            else if (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(double?))
                meta.Type = "double";


            var nullabilityContext = new NullabilityInfoContext();
            var nullabilityInfo = nullabilityContext.Create(pi);
            if (nullabilityInfo.WriteState == NullabilityState.NotNull)
            {
                meta.IsRequire = true;
            }

            foreach (var att in pi.GetCustomAttributes(true))
            {
                if (att is DescriptionAttribute desc)
                    meta.Caption = desc.Description;
                else if (att is RequiredAttribute req)
                    meta.IsRequire = true;
                else if (att is MaxLengthAttribute ml)
                    meta.MaxLen = ml.Length;
            }
            res.Add(meta);
        }
        return Task.FromResult(res);
    }
}

/// <summary> Метаданные </summary>
public class MetaInformation
{
    public MetaInformation(string name)
    {
        this.Name = name;
        this.Caption = name;
    }

    public string Name { get; }

    public string Caption { get; set; }

    public bool IsRequire { get; set; }

    public string Type { get; set; } = "string";

    public int MaxLen { get; set; }
}

/// <summary> Объект с метаданными </summary>
/// <typeparam name="T"></typeparam>
public class DataWithMeta<T>
{
    public DataWithMeta(T? entity)
    {
        this.Entity = entity;
        this.Meta = new Dictionary<string, List<MetaInformation>>();
    }
    
    public T? Entity { get; set; }
    
    public Dictionary<string, List<MetaInformation>> Meta { get; set; }
}
