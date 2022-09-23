namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// trusted-types policy.
/// </summary>
[PolicyOptions]
[AddAllowDuplicates]
[AddNone]
[AddPolicyName]
public sealed partial class TrustedTypesPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// trusted-types policy.
/// </summary>
[Policy("trusted-types")]
public sealed partial class TrustedTypesPolicy : PolicyBase
{
}
