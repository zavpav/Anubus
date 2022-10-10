using System.Diagnostics;

namespace TestConsoleTest;

public static class CodeStyleExtension
{
    public static void Assert(bool condition, string? descr = null)
    {
        if (!condition)
        {
            if (!string.IsNullOrEmpty(descr))
            {
                Debug.Assert(condition, descr);
                throw new NotSupportedException(descr);
            }
            else
            {
                Debug.Assert(condition);
                throw new NotSupportedException();
            }
        }
    }

    public static void ThrowIfNull(this object? arg, string? descr = null)
    {
        NotNull(arg, descr);
    }

    public static T NotNull<T>(this T? arg, string? descr = null)
        where T : class
    {
        if (arg == null)
        {
            if (!string.IsNullOrWhiteSpace(descr))
                throw new NullReferenceException(descr);
            else
                throw new NullReferenceException();
        }

        return arg;
    }

    public static T NotNull<T>(this T? arg, Func<string> descrFunc)
        where T : class
    {
        if (arg == null)
        {
            var descr = descrFunc();

            if (!string.IsNullOrWhiteSpace(descr))
                throw new NullReferenceException(descr);
            else
                throw new NullReferenceException();
        }

        return arg;
    }
}
