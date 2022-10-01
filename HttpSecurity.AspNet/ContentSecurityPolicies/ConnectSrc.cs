namespace HttpSecurity.AspNet;


/// <summary>
/// connect-src policy.
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
public sealed partial class ConnectSrcOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// connect-src policy.
/// </summary>
[ContentSecurityPolicy("connect-src")]
public sealed partial class ConnectSrc : ContentSecurityPolicyBase
{
}
