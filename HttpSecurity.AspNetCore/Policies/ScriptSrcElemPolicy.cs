namespace HttpSecurity.AspNetCore;


/// <summary>
/// script-src-elem policy.
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
public sealed partial class ScriptSrcElemPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// script-src-elem policy.
/// </summary>
[Policy("script-src-elem")]
public sealed partial class ScriptSrcElemPolicy : PolicyBase
{
}
