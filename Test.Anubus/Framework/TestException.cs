namespace TestConsoleTest.Framework;

[Serializable]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
public sealed class TestException : IgnoreException
{
    public TestException(string info, params object[] args) : base(string.Format(info, args)) { }
}