using System.Linq.Expressions;
using System.Reflection;

namespace TestConsoleTest;

/// <summary> Вспомогательные методы работы с типами </summary>
public static class TypePropertyHelper
{

    /// <summary> Проверка, что объект реализует данный интерфейс </summary>
    public static bool Implements<T>(this Type type)
        where T : class
    {
        return typeof(T).IsGenericTypeDefinition
            ? type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(T))
            : typeof(T).IsAssignableFrom(type);
    }

    /// <summary> Проверка, что объект реализует данный интерфейс </summary>
    public static bool Implements(this Type type, Type interafaceType)
    {
        return interafaceType.IsGenericTypeDefinition
            ? type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == interafaceType)
            : interafaceType.IsAssignableFrom(type);
    }

    /// <summary> Проверка, что объект реализует данный интерфейс </summary>
    public static bool CheckInterface(object sprRow, Type interfaceType)
    {
        return sprRow.GetType().GetInterfaces().Any(t => t == interfaceType);
    }


    /// <summary> Получить список всех свойств объекта </summary>
    public static PropertyInfo[] GetPropertiesInfo(this Type domainType)
    {
        return domainType.GetProperties(BindingFlags.FlattenHierarchy
                                        | BindingFlags.Instance
                                        | BindingFlags.Public);
    }

    /// <summary> Получить имя свойства </summary>
    public static string DomainPropertyName<T>(this T? t, Expression<Func<T, object>> displayMember)
        where T : class
    {
        return displayMember.ExpressionMemberProperty().Name;
    }


    /// <summary> Получить member свойства из Expression </summary>
    /// <typeparam name="TDomain">Тип доменного объекта</typeparam>
    /// <param name="property">Expression свойства</param>
    public static MemberInfo ExpressionMemberProperty<TDomain>(this Expression<Func<TDomain, object>> property)
        where TDomain : class
    {
        var lambda = (LambdaExpression)property;
        MemberExpression memberExpression;

        if (lambda.Body is UnaryExpression)
        {
            var unaryExpression = (UnaryExpression)lambda.Body;
            memberExpression = (MemberExpression)unaryExpression.Operand;
        }
        else
            memberExpression = (MemberExpression)lambda.Body;
        return memberExpression.Member;
    }

    /// <summary> Получить member свойства из Expression </summary>
    /// <typeparam name="TDomain">Тип доменного объекта</typeparam>
    /// <typeparam name="TReturnType">Тип возвращаемого значения</typeparam>
    /// <param name="property">Expression свойства</param>
    /// <returns></returns>
    public static MemberInfo ExpressionMemberPropertyTyped<TDomain, TReturnType>(this Expression<Func<TDomain, TReturnType>> property)
                where TDomain : class
    {
        var lambda = (LambdaExpression)property;
        MemberExpression memberExpression;

        if (lambda.Body is UnaryExpression)
        {
            var unaryExpression = (UnaryExpression)lambda.Body;
            memberExpression = (MemberExpression)unaryExpression.Operand;
        }
        else
            memberExpression = (MemberExpression)lambda.Body;
        return memberExpression.Member;
    }


    /// <summary>
    /// Получить MethodInfo из Expression
    /// bool Method(TDomainType d)
    /// </summary>
    /// <typeparam name="TDomain">Тип доменного объекта</typeparam>
    /// <typeparam name="TReturnType">Возвращаемое значение функции</typeparam>
    /// <param name="method">Expression метода</param>
    /// <returns>MethodInfo</returns>
    public static MemberInfo ExpressionMemberMethodInfo<TDomain, TReturnType>(this Expression<Func<TDomain, Func<TDomain, TReturnType>>> method)
        where TDomain : class
    {
        var callExpression = (MethodCallExpression)((UnaryExpression)method.Body).Operand;
        var methodConstantExpression = (ConstantExpression)callExpression.Arguments[2];
        var memberInfo = (MemberInfo)methodConstantExpression.Value;
        if (memberInfo == null)
            throw new TestException("memberInfo == null. Вроде нельзя у меня");
        return memberInfo;
    }

    /// <summary> Получить member свойства из Expression </summary>
    /// <param name="property">Expression свойства</param>
    /// <returns></returns>
    public static MemberInfo GetMemberInfo(this Expression property)
    {
        var lambda = (LambdaExpression)property;
        MemberExpression memberExpression;

        if (lambda.Body is UnaryExpression)
        {
            var unaryExpression = (UnaryExpression)lambda.Body;
            memberExpression = (MemberExpression)unaryExpression.Operand;
        }
        else
            memberExpression = (MemberExpression)lambda.Body;
        return memberExpression.Member;
    }

    /// <summary> Создать getter данных для свойства </summary>
    /// <typeparam name="T">Базовый объект</typeparam>
    /// <typeparam name="TV">Возвращаемое значение</typeparam>
    /// <param name="propertyName">Имя свойства</param>
    /// <returns>Func получения данных типа TV из строки типа T </returns>
    /// <exception cref="NotSupportedException">Не найдено свойство</exception>
    public static Func<T, TV> CreateGetter<T, TV>(string propertyName)
    {
        try
        {
            var instance = Expression.Parameter(typeof(T), "i");
            var cast = Expression.TypeAs(Expression.Property(instance, propertyName), typeof(TV));
            return (Func<T, TV>)Expression.Lambda(cast, instance).Compile();
        }
        catch (ArgumentException argumentException)
        {
            throw new NotSupportedException("Не найдено свойство " + propertyName, argumentException);
        }

        //var parameter = Expression.Parameter(typeof(T1));
        //var lambda = Expression.Lambda<Func<T1, T2>>(
        //    Expression.Convert(Expression.Property(Expression.Convert(parameter, this._modelType), k), typeof(object)),
        //    parameter);
    }

    /// <summary> Создать getter данных для свойства </summary>
    /// <typeparam name="T">Базовый объект</typeparam>
    /// <typeparam name="TV">Возвращаемое значение</typeparam>
    /// <param name="propertyName">Имя свойства</param>
    /// <returns>Func получения данных типа TV из строки типа T </returns>
    /// <exception cref="NotSupportedException">Не найдено свойство</exception>
    public static Action<T, TV> CreateSetter<T, TV>(string propertyName)
    {

        try
        {
            var instance = Expression.Parameter(typeof(T), "i");
            var val = Expression.Parameter(typeof(TV), "v");
            var sett = Expression.Assign(Expression.Property(instance, propertyName), val);
            return Expression.Lambda<Action<T, TV>>(sett, instance, val).Compile();
        }
        catch (ArgumentException argumentException)
        {
            throw new NotSupportedException("Не найдено свойство " + propertyName, argumentException);
        }


        //var parameter = Expression.Parameter(typeof(T1));
        //var lambda = Expression.Lambda<Func<T1, T2>>(
        //    Expression.Convert(Expression.Property(Expression.Convert(parameter, this._modelType), k), typeof(object)),
        //    parameter);

    }


    /// <summary> Создать getter данных для свойства </summary>
    /// <typeparam name="T">Базовый объект</typeparam>
    /// <typeparam name="TV">Возвращаемое значение</typeparam>
    /// <param name="propertyName">Имя свойства</param>
    /// <returns>Func получения данных типа TV из строки типа T </returns>
    /// <exception cref="NotSupportedException">Не найдено свойство</exception>
    public static Func<T, TV> CreateGetterStruct<T, TV>(string propertyName)
    {

        try
        {
            var instance = Expression.Parameter(typeof(T), "i");
            var cast = Expression.Property(instance, propertyName);
            return (Func<T, TV>)Expression.Lambda(cast, instance).Compile();
        }
        catch (ArgumentException argumentException)
        {
            throw new NotSupportedException("Не найдено свойство " + propertyName, argumentException);
        }
    }

    /// <summary> Создать getter данных для свойства </summary>
    /// <typeparam name="T">Базовый объект</typeparam>
    /// <typeparam name="TV">Возвращаемое значение</typeparam>
    /// <param name="propertyName">Имя свойства</param>
    /// <returns>Func получения данных типа TV из строки типа T </returns>
    /// <exception cref="NotSupportedException">Не найдено свойство</exception>
    public static Action<T, TV> CreateSetterStruct<T, TV>(string propertyName)
    {
        try
        {
            var instance = Expression.Parameter(typeof(T), "i");
            var val = Expression.Parameter(typeof(TV), "v");
            var sett = Expression.Assign(Expression.Property(instance, propertyName), val);
            return Expression.Lambda<Action<T, TV>>(sett, instance, val).Compile();
        }
        catch (ArgumentException argumentException)
        {
            throw new NotSupportedException("Не найдено свойство " + propertyName, argumentException);
        }

        //var parameter = Expression.Parameter(typeof(T1));
        //var lambda = Expression.Lambda<Func<T1, T2>>(
        //    Expression.Convert(Expression.Property(Expression.Convert(parameter, this._modelType), k), typeof(object)),
        //    parameter);

    }



    /// <summary> Создать функцию сравнения объекта со значением по одному полю </summary>
    /// <typeparam name="T">Тип или интерфейс сравниваемого типа</typeparam>
    /// <param name="type">Сравниваемый тип данных</param>
    /// <param name="name">Имя свойства</param>
    /// <param name="val">Значение с которым сравниваем</param>
    /// <returns></returns>
    public static Func<T, bool> CreateEqual<T>(Type type, string name, object val)
    {
        var param = Expression.Parameter(typeof(T), "t");
        var exp = GetEqualExpression(type, param, name, val);
        return Expression.Lambda<Func<T, bool>>(exp, param).Compile();
    }

    /// <summary> Создать expression сравнения поля типа с неким значением </summary>
    private static Expression GetEqualExpression(Type type, Expression param, string propertyName, object val)
    {
        var converted = Expression.Convert(param, type);
        var member = Expression.Property(converted, propertyName);
        var constant = Expression.Constant(val);
        return Expression.Equal(member, constant);
    }
}

