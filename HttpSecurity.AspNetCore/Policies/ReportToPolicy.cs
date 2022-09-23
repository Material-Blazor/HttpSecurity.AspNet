namespace HttpSecurity.AspNetCore;


/// <summary>
/// report-to policy.
/// </summary>
[PolicyOptions]
[AddGroupName]
public sealed partial class ReportToPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// report-to policy.
/// </summary>
[Policy("report-to")]
public sealed partial class ReportToPolicy : PolicyBase
{
}
