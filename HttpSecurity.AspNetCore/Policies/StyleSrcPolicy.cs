namespace HttpSecurity.AspNetCore;


/// <summary>
/// style-src policy.
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
public sealed partial class StyleSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// style-src policy.
/// </summary>
[Policy("style-src")]
public sealed partial class StyleSrcPolicy : PolicyBase
{
}
