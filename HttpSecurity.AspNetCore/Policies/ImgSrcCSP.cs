namespace HttpSecurity.AspNetCore;


/// <summary>
/// img-src policy.
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
public sealed partial class ImgSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// img-src policy.
/// </summary>
[ContentSecurityPolicy("img-src")]
public sealed partial class ImgSrcCSP : ContentSecurityPolicyBase
{
}
