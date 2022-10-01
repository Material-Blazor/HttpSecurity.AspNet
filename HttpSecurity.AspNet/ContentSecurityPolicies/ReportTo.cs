namespace HttpSecurity.AspNet;


/// <summary>
/// report-to policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddGroupName]
public sealed partial class ReportToOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// report-to policy.
/// </summary>
[ContentSecurityPolicy("report-to")]
public sealed partial class ReportTo : ContentSecurityPolicyBase
{
}
