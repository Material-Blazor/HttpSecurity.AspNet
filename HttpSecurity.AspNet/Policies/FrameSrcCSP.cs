namespace HttpSecurity.AspNet;


/// <summary>
/// frame-src policy.
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
public sealed partial class FrameSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// frame-src policy.
/// </summary>
[ContentSecurityPolicy("frame-src")]
public sealed partial class FrameSrcCSP : ContentSecurityPolicyBase
{
}
