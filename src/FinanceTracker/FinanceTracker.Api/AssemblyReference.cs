using System.Reflection;

namespace FinanceTracker.Api;

internal static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
