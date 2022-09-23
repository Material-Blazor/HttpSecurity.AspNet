namespace HttpSecurity.AspNetCore;


/// <summary>
/// navigate-to policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddHashValue]
[AddHostSource]
[AddNone]
[AddNonce]
[AddReportSample]
[AddSelf]
[AddSchemeSource]
[AddStrictDynamic]
[AddUnsafeEval]
[AddUnsafeHashes]
[AddUnsafeInline]
[AddUri]
public sealed partial class NavigateToCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// navigate-to policy.
/// </summary>
[ContentSecurityPolicy("navigate-to")]
public sealed partial class NavigateToCSP : ContentSecurityPolicyBase
{
}
