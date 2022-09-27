namespace HttpSecurity.AspNet;


/// <summary>
/// block-all-mixed-content policy - considered deprecated.
/// </summary>
[ContentSecurityPolicyOptions]
public sealed partial class BlockAllMixedContentCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// block-all-mixed-content policy - considered deprecated.
/// </summary>
[ContentSecurityPolicy("block-all-mixed-content")]
public sealed partial class BlockAllMixedContentCSP : ContentSecurityPolicyBase
{
}
