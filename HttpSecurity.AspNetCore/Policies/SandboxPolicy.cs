namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// sandbox policy.
/// </summary>
[PolicyOptions]
[AddAllowDownloads]
[AddAllowDownloadsWithoutUserActivation]
[AddAllowForms]
[AddAllowModals]
[AddAllowOrientationLock]
[AddAllowPointerLock]
[AddAllowPopups]
[AddAllowPopupsToEscapeSandbox]
[AddAllowPresentation]
[AddAllowSameOrigin]
[AddAllowScripts]
[AddAllowStorageAccessByUserActivation]
[AddAllowTopNavigation]
[AddAllowTopNavigationAccessByUserActivation]
[AddAllowTopNavigationToCustomProtocols]

public sealed partial class SandboxPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// sandbox policy.
/// </summary>
[Policy("sandbox")]
public sealed partial class SandboxPolicy : PolicyBase
{
}
