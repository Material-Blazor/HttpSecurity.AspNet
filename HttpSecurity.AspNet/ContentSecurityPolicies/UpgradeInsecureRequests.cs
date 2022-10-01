namespace HttpSecurity.AspNet;


/// <summary>
/// upgrade-insecure-requests policy.
/// </summary>
[ContentSecurityPolicyOptions]
public sealed partial class UpgradeInsecureRequestsOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// upgrade-insecure-requests policy.
/// </summary>
[ContentSecurityPolicy("upgrade-insecure-requests")]
public sealed partial class UpgradeInsecureRequests : ContentSecurityPolicyBase
{
}
