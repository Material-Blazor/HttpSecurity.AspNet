namespace HttpSecurity.AspNet;


/// <summary>
/// block-all-mixed-content policy - deprecated. Use upgrade-insecure-requests instead.
/// </summary>
[Obsolete("block-all-mixed-content is deprecated by the CSP specification. Use upgrade-insecure-requests instead.")]
[ContentSecurityPolicyOptions]
public sealed partial class BlockAllMixedContentOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// block-all-mixed-content policy - deprecated. Use upgrade-insecure-requests instead.
/// </summary>
[Obsolete("block-all-mixed-content is deprecated by the CSP specification. Use upgrade-insecure-requests instead.")]
[ContentSecurityPolicy("block-all-mixed-content")]
public sealed partial class BlockAllMixedContent : ContentSecurityPolicyBase
{
}
