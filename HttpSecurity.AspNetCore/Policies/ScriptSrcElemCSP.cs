namespace HttpSecurity.AspNetCore;


/// <summary>
/// script-src-elem policy.
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
public sealed partial class ScriptSrcElemCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// script-src-elem policy.
/// </summary>
[ContentSecurityPolicy("script-src-elem")]
public sealed partial class ScriptSrcElemCSP : ContentSecurityPolicyBase
{
}
