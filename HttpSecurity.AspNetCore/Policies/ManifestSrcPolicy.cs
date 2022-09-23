namespace HttpSecurity.AspNetCore;


/// <summary>
/// manifest-src policy.
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
public sealed partial class ManifestSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// manifest-src policy.
/// </summary>
[Policy("manifest-src")]
public sealed partial class ManifestSrcPolicy : PolicyBase
{
}
