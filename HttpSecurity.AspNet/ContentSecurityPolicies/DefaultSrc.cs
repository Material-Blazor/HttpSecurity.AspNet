namespace HttpSecurity.AspNet;


/// <summary>
/// default-src policy.
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
public sealed partial class DefaultSrcOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// default-src policy.
/// </summary>
[ContentSecurityPolicy("default-src")]
public sealed partial class DefaultSrc : ContentSecurityPolicyBase
{
}
