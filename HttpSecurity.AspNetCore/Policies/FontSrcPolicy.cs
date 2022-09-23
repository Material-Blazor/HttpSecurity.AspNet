namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// font-src policy.
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
public sealed partial class FontSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// font-src policy.
/// </summary>
[Policy("font-src")]
public sealed partial class FontSrcPolicy : PolicyBase
{
}
