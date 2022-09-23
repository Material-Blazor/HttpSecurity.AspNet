namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// form-action policy.
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
public sealed partial class FormActionPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// form-action policy.
/// </summary>
[Policy("form-action")]
public sealed partial class FormActionPolicy : PolicyBase
{
}
