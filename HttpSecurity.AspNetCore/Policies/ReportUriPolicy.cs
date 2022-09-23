namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// report-uri policy - considered deprecated.
/// </summary>
[PolicyOptions]
[AddUri]
public sealed partial class ReportUriPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// report-uri policy - considered deprecated.
/// </summary>
[Policy("report-uri")]
public sealed partial class ReportUriPolicy : PolicyBase
{
}
