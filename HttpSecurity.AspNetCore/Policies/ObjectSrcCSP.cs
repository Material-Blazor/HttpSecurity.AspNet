namespace HttpSecurity.AspNetCore;


/// <summary>
/// object-src policy.
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
public sealed partial class ObjectSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// object-src policy.
/// </summary>
[ContentSecurityPolicy("object-src")]
public sealed partial class ObjectSrcCSP : ContentSecurityPolicyBase
{
}
