namespace HttpSecurity.AspNet;


/// <summary>
/// require-trusted-types-for policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddScript]
public sealed partial class RequireTrustedTypesForCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// require-trusted-types-for policy.
/// </summary>
[ContentSecurityPolicy("require-trusted-types-for")]
public sealed partial class RequireTrustedTypesForCSP : ContentSecurityPolicyBase
{
}
