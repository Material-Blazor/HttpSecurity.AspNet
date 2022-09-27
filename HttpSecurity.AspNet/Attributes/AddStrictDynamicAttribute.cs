namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddStrictDynamic()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddStrictDynamicAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'strict-dynamic'";
}
