﻿namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// connect-src policy.
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
public sealed partial class ConnectSrcPolicyOptions : PolicyOptionsBase
{
}


/// <summary>
/// connect-src policy.
/// </summary>
[Policy("connect-src")]
public sealed partial class ConnectSrcPolicy : PolicyBase
{
}
