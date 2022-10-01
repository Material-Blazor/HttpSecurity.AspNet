namespace HttpSecurity.AspNet;


/// <summary>
/// child-src policy.
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
public sealed partial class ChildSrcOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// child-src policy.
/// </summary>
[ContentSecurityPolicy("child-src")]
public sealed partial class ChildSrc : ContentSecurityPolicyBase
{
}
