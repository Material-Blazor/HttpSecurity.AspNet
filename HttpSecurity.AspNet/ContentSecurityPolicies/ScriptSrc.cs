namespace HttpSecurity.AspNet;


/// <summary>
/// script-src policy.
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
public sealed partial class ScriptSrcOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// script-src policy.
/// </summary>
[ContentSecurityPolicy("script-src")]
public sealed partial class ScriptSrc : ContentSecurityPolicyBase
{
}
