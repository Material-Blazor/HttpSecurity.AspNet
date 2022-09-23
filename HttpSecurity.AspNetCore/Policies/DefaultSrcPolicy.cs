namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// default-src policy.
/// </summary>
[PolicyOptions]
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
public sealed partial class DefaultSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// default-src policy.
/// </summary>
[Policy("default-src")]
public sealed partial class DefaultSrcPolicy : PolicyBase
{
}
