namespace HttpSecurity.AspNetCore;


/// <summary>
/// script-src policy.
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
public sealed partial class ScriptSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// script-src policy.
/// </summary>
[Policy("script-src")]
public sealed partial class ScriptSrcPolicy : PolicyBase
{
}
