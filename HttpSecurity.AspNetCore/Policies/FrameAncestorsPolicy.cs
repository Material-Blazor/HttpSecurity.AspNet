﻿namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// frame-ancestors policy.
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
[AddUnsafeHashes]
public sealed partial class FrameAncestorsPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// frame-ancestors policy.
/// </summary>
[Policy("frame-ancestors")]
public sealed partial class FrameAncestorsPolicy : PolicyBase
{
}
