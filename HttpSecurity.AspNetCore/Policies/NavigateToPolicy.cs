namespace HttpSecurity.AspNetCore;


/// <summary>
/// navigate-to policy.
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
public sealed partial class NavigateToPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// navigate-to policy.
/// </summary>
[Policy("navigate-to")]
public sealed partial class NavigateToPolicy : PolicyBase
{
}
