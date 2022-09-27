namespace HttpSecurity.AspNet;


/// <summary>
/// frame-ancestors policy.
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
[AddUnsafeHashes]
[AddUri]
public sealed partial class FrameAncestorsCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// frame-ancestors policy.
/// </summary>
[ContentSecurityPolicy("frame-ancestors")]
public sealed partial class FrameAncestorsCSP : ContentSecurityPolicyBase
{
}
