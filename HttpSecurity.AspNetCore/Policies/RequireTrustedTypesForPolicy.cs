namespace HttpSecurity.AspNetCore;


/// <summary>
/// require-trusted-types-for policy.
/// </summary>
[PolicyOptions]
[AddScript]
public sealed partial class RequireTrustedTypesForPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// require-trusted-types-for policy.
/// </summary>
[Policy("require-trusted-types-for")]
public sealed partial class RequireTrustedTypesForPolicy : PolicyBase
{
}
