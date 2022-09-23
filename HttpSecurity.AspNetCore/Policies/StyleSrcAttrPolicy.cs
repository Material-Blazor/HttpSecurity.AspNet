namespace HttpSecurity.AspNetCore;


/// <summary>
/// style-src-attr policy.
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
public sealed partial class StyleSrcAttrPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// style-src-attr policy.
/// </summary>
[Policy("style-src-attr")]
public sealed partial class StyleSrcAttrPolicy : PolicyBase
{
}
