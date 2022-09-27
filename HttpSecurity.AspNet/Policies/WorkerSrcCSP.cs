namespace HttpSecurity.AspNet;


/// <summary>
/// worker-src policy.
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
public sealed partial class WorkerSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// worker-src policy.
/// </summary>
[ContentSecurityPolicy("worker-src")]
public sealed partial class WorkerSrcCSP : ContentSecurityPolicyBase
{
}
