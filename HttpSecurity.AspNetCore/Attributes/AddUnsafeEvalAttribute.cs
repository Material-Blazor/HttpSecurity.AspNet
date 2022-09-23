namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddUnsafeEval()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddUnsafeEvalAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'unsafe-eval'";
}
