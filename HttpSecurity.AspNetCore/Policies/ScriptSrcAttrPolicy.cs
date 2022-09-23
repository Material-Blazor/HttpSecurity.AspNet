namespace ContentSecurityPolicy.AspNetCore;


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
