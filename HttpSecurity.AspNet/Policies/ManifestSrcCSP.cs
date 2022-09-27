namespace HttpSecurity.AspNet;


/// <summary>
/// manifest-src policy.
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
public sealed partial class ManifestSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// manifest-src policy.
/// </summary>
[ContentSecurityPolicy("manifest-src")]
public sealed partial class ManifestSrcCSP : ContentSecurityPolicyBase
{
}
