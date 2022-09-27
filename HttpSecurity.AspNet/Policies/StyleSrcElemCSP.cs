namespace HttpSecurity.AspNet;


/// <summary>
/// style-src-elem policy.
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
public sealed partial class StyleSrcElemCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// style-src-elem policy.
/// </summary>
[ContentSecurityPolicy("style-src-elem")]
public sealed partial class StyleSrcElemCSP : ContentSecurityPolicyBase
{
}
