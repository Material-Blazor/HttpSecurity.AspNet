namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowStorageAccessByUserActivation()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowStorageAccessByUserActivationAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-storage-access-by-user-activation'";
}
