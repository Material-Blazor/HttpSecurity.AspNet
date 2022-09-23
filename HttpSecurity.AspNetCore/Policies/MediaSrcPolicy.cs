﻿namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// media-src policy.
/// </summary>
[PolicyOptions]
[AddHashValue]
[AddHostSource]
[AddNone]
[AddNonce]
[AddReportSample]
[AddSelf]
[AddSchemeSource]
[AddStrictDynamic]
[AddUnsafeEval]
[AddUnsafeHashes]
[AddUnsafeInline]
public sealed partial class MediaSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// media-src policy.
/// </summary>
[Policy("media-src")]
public sealed partial class MediaSrcPolicy : PolicyBase
{
}
