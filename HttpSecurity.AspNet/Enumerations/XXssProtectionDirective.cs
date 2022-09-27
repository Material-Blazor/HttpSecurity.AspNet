namespace HttpSecurity.AspNet;

/// <summary>
/// X-Frame-Options directives.
/// </summary>
public enum XXssProtectionDirective
{
    /// <summary>
    /// 0
    /// </summary>
    Zero,


    /// <summary>
    /// 1
    /// </summary>
    One,


    /// <summary>
    /// 1; mode=block
    /// </summary>
    OneModeBlock,


    /// <summary>
    /// 1; report=&lt;reportingUri&gt;
    /// </summary>
    OneReportWithUri,
}
