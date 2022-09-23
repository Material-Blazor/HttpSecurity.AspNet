namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// upgrade-insecure-requests policy.
/// </summary>
[PolicyOptions]
public sealed partial class UpgradeInsecureRequestsPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// upgrade-insecure-requests policy.
/// </summary>
[Policy("upgrade-insecure-requests")]
public sealed partial class UpgradeInsecureRequestsPolicy : PolicyBase
{
}
