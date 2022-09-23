namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// block-all-mixed-content policy - considered deprecated.
/// </summary>
[PolicyOptions]
public sealed partial class BlockAllMixedContentPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// block-all-mixed-content policy - considered deprecated.
/// </summary>
[Policy("block-all-mixed-content")]
public sealed partial class BlockAllMixedContentPolicy : PolicyBase
{
}
