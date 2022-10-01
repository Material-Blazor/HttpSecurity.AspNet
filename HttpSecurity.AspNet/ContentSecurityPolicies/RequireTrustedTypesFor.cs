namespace HttpSecurity.AspNet;


/// <summary>
/// require-trusted-types-for policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddScript]
public sealed partial class RequireTrustedTypesForOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// require-trusted-types-for policy.
/// </summary>
[ContentSecurityPolicy("require-trusted-types-for")]
public sealed partial class RequireTrustedTypesFor : ContentSecurityPolicyBase
{
}
