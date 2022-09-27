namespace HttpSecurity.AspNet;


/// <summary>
/// style-src-attr policy.
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
public sealed partial class StyleSrcAttrCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// style-src-attr policy.
/// </summary>
[ContentSecurityPolicy("style-src-attr")]
public sealed partial class StyleSrcAttrCSP : ContentSecurityPolicyBase
{
}
