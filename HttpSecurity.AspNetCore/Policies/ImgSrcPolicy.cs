namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// img-src policy.
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
public sealed partial class ImgSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// img-src policy.
/// </summary>
[Policy("img-src")]
public sealed partial class ImgSrcPolicy : PolicyBase
{
}
