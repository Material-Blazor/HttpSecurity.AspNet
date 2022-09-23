namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowModals()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowModalsAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-modals'";
}
