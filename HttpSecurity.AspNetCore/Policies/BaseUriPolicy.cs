namespace HttpSecurity.AspNetCore;


/// <summary>
/// base-uri policy.
/// </summary>
[PolicyOptions]
[AddHashValue]
[AddHostSource]
[AddNone]
[AddNonce]
[AddReportSample]
[AddSelf]
[AddSchemeSource]
[AddUnsafeEval]
[AddUnsafeHashes]
[AddUri]
public sealed partial class BaseUriPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// base-uri policy.
/// </summary>
[Policy("base-uri")]
public sealed partial class BaseUriPolicy : PolicyBase
{
}
