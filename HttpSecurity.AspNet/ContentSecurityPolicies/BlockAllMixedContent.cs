namespace HttpSecurity.AspNet;


/// <summary>
/// block-all-mixed-content policy - considered deprecated.
/// </summary>
[ContentSecurityPolicyOptions]
public sealed partial class BlockAllMixedContentOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// block-all-mixed-content policy - considered deprecated.
/// </summary>
[ContentSecurityPolicy("block-all-mixed-content")]
public sealed partial class BlockAllMixedContent : ContentSecurityPolicyBase
{
}
