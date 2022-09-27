namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowOrientationLock()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowOrientationLockAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-orientation-lock'";
}
