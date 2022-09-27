namespace HttpSecurity.AspNet;

/// <summary>
/// XPermittedCrossDomainPolicies directives.
/// </summary>
public enum XPermittedCrossDomainPoliciesDirective
{
    /// <summary>
    /// all
    /// </summary>
    All,


    /// <summary>
    /// by-content-only
    /// </summary>
    ByContentOnly,


    /// <summary>
    /// by-ftp-only
    /// </summary>
    ByFtpOnly,


    /// <summary>
    /// master-only
    /// </summary>
    MasterOnly,


    /// <summary>
    /// none
    /// </summary>
    None,
}
