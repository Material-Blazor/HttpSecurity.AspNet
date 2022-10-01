namespace HttpSecurity.AspNet;


/// <summary>
/// trusted-types policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddAllowDuplicates]
[AddNone]
[AddPolicyName]
public sealed partial class TrustedTypesOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// trusted-types policy.
/// </summary>
[ContentSecurityPolicy("trusted-types")]
public sealed partial class TrustedTypes : ContentSecurityPolicyBase
{
}
