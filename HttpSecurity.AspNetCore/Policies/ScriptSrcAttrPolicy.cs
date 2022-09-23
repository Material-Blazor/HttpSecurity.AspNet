namespace HttpSecurity.AspNetCore;


/// <summary>
/// script-src-attr policy.
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
public sealed partial class ScriptSrcAttrPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// script-src-attr policy.
/// </summary>
[Policy("script-src-attr")]
public sealed partial class ScriptSrcAttrPolicy : PolicyBase
{
}
