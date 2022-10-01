namespace HttpSecurity.AspNet;


/// <summary>
/// sandbox policy.
/// </summary>
[ContentSecurityPolicyOptions]
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
public sealed partial class SandboxOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// sandbox policy.
/// </summary>
[ContentSecurityPolicy("sandbox")]
public sealed partial class Sandbox : ContentSecurityPolicyBase
{
}
