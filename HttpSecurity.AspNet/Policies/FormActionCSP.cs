namespace HttpSecurity.AspNet;


/// <summary>
/// form-action policy.
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
public sealed partial class FormActionCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// form-action policy.
/// </summary>
[ContentSecurityPolicy("form-action")]
public sealed partial class FormActionCSP : ContentSecurityPolicyBase
{
}
