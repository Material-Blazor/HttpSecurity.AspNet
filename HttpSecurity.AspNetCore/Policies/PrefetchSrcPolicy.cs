namespace HttpSecurity.AspNetCore;


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
[AddUri]
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
