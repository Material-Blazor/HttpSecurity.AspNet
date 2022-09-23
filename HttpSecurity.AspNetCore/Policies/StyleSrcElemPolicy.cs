namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// style-src-elem policy.
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
public sealed partial class StyleSrcElemPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// style-src-elem policy.
/// </summary>
[Policy("style-src-elem")]
public sealed partial class StyleSrcElemPolicy : PolicyBase
{
}
