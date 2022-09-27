namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowPointerLock()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowPointerLockAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-pointer-lock'";
}
