namespace HttpSecurity.AspNet;


/// <summary>
/// script-src-attr policy.
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
public sealed partial class ScriptSrcAttrCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// script-src-attr policy.
/// </summary>
[ContentSecurityPolicy("script-src-attr")]
public sealed partial class ScriptSrcAttrCSP : ContentSecurityPolicyBase
{
}
