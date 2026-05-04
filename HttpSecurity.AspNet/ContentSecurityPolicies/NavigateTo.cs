namespace HttpSecurity.AspNet;


/// <summary>
/// navigate-to policy - removed from the CSP Level 3 specification with no browser support.
/// </summary>
[Obsolete("navigate-to was removed from the CSP Level 3 specification and has no browser support. Remove this directive.")]
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
public sealed partial class NavigateToOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// navigate-to policy - removed from the CSP Level 3 specification with no browser support.
/// </summary>
[Obsolete("navigate-to was removed from the CSP Level 3 specification and has no browser support. Remove this directive.")]
[ContentSecurityPolicy("navigate-to")]
public sealed partial class NavigateTo : ContentSecurityPolicyBase
{
}
