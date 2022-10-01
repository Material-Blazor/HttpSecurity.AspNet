namespace HttpSecurity.AspNet;


/// <summary>
/// report-uri policy - considered deprecated.
/// </summary>
[ContentSecurityPolicyOptions]
[AddUri]
public sealed partial class ReportUriOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// report-uri policy - considered deprecated.
/// </summary>
[ContentSecurityPolicy("report-uri")]
public sealed partial class ReportUri : ContentSecurityPolicyBase
{
}
