namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddReportSample()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddReportSampleAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'report-sample'";
}
