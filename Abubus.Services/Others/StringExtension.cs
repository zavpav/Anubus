namespace Anubus;

public static class StringExtension
{
    /// <summary> Нижний регистр первого символа </summary>
    /// <returns>Строка с lowercase первого символа</returns>
    public static string ToLowerFirst(this string str)
    {
        if (str.Length == 0)
            return str;
        if (str.Length == 1)
            return str.ToLower();
        return char.ToLower(str[0]) + str.Substring(1);
    }
}
