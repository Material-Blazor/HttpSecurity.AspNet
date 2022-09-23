namespace HttpSecurity.AspNetCore;


/// <summary>
/// child-src policy.
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
[AddUri]
public sealed partial class ChildSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// child-src policy.
/// </summary>
[Policy("child-src")]
public sealed partial class ChildSrcPolicy : PolicyBase
{
}
