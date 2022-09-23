namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// object-src policy.
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
public sealed partial class ObjectSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// object-src policy.
/// </summary>
[Policy("object-src")]
public sealed partial class ObjectSrcPolicy : PolicyBase
{
}
