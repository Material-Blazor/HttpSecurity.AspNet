namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// prefetch-src policy.
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
public sealed partial class PrefetchSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// prefetch-src policy.
/// </summary>
[Policy("prefetch-src")]
public sealed partial class PrefetchSrcPolicy : PolicyBase
{
}
