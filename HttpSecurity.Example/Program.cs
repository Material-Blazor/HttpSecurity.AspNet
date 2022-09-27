using HttpSecurity.AspNetCore;
using HttpSecurity.AspNetCore.Extensions;
using HttpSecurity.Example.Data;

var builder = WebApplication.CreateBuilder(args);

string[] files = Directory.GetFiles(builder.Environment.WebRootPath,
            "*.js",
            SearchOption.AllDirectories);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpsSecurityHeaders(options =>
{
    options
        // Content Security Policies
        .AddBaseUriCSP(o => o.AddSelf())
        .AddBlockAllMixedContentCSP()
        .AddChildSrcCSP(o => o.AddSelf())
        .AddConnectSrcCSP(o => o.AddSelf().AddUri((baseUri, baseDomain) => $"wss://{baseDomain}:*"))
        .AddDefaultSrcCSP(o => o.AddSelf().AddStrictDynamicIf(() => !builder.Environment.IsDevelopment()).AddUnsafeInline())
        .AddFontSrcCSP(o => o.AddSelf())
        .AddFrameAncestorsCSP(o => o.AddNone())
        .AddFrameSrcCSP(o => o.AddSelf())
        .AddFormActionCSP(o => o.AddNone())
        .AddImgSrcCSP(o => o.AddSelf().AddUri("www.google-analytics.com").AddUri("*.openstreetmap.org").AddSchemeSource(SchemeSource.Data, "w3.org/svg/2000"))
        .AddManifestSrcCSP(o => o.AddSelf())
        .AddMediaSrcCSP(o => o.AddSelf())
        .AddPrefetchSrcCSP(o => o.AddSelf())
        .AddObjectSrcCSP(o => o.AddNone())
        .AddReportUriCSP(o => o.AddUri((baseUri, baseDomain) => $"https://{baseUri}/api/CspReporting/UriReport"))
        .AddScriptSrcCSP(o => o.AddSelf().AddNonce().AddHashValue(HashAlgorithm.SHA256, "v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=").AddUriIf((baseUri, baseDomain) => $"https://{baseUri}/_framework/aspnetcore-browser-refresh.js", () => builder.Environment.IsDevelopment()).AddStrictDynamicIf(() => !builder.Environment.IsDevelopment()).AddUnsafeInline().AddReportSample().AddUnsafeEval().AddUri("https://www.googletagmanager.com/gtag/js").AddGeneratedHashValues(StaticFileExtension.JS))
        .AddStyleSrcCSP(o => o.AddSelf().AddUnsafeInline().AddUnsafeHashes().AddReportSample())
        .AddUpgradeInsecureRequestsCSP()
        .AddWorkerSrcCSP(o => o.AddSelf())

        // Other headers
        .AddCacheControl("public, max-age=86400")
        .AddExpires("0")
        .AddReferrerPolicy(ReferrerPolicyDirective.NoReferrer)
        .AddPermissionsPolicy("accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()")
        .AddStrictTransportSecurity(31536000, true)
        .AddXClientId("Material.Blazor")
        .AddXContentTypeOptionsNoSniff()
        .AddXFrameOptionsDirective(XFrameOptionsDirective.Deny)
        .AddXXssProtectionDirective(XXssProtectionDirective.OneModeBlock)
        .AddXPermittedCrossDomainPoliciesDirective(XPermittedCrossDomainPoliciesDirective.None);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseHttpSecurityHeaders();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
