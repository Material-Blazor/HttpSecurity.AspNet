namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// worker-src policy.
/// </summary>
[PolicyOptions]
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
public sealed partial class WorkerSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// worker-src policy.
/// </summary>
[Policy("worker-src")]
public sealed partial class WorkerSrcPolicy : PolicyBase
{
}
