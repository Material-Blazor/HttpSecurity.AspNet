﻿namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// frame-src policy.
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
public sealed partial class FrameSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// frame-src policy.
/// </summary>
[Policy("frame-src")]
public sealed partial class FrameSrcPolicy : PolicyBase
{
}
