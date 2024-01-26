using HttpSecurity.AspNet;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpsSecurityHeaders(options =>
{
    options
        .AddContentSecurityOptions(cspOptions =>
        {
            cspOptions
                .AddBaseUri(o => o.AddSelf())

                .AddBlockAllMixedContent()

                .AddChildSrc(o => o.AddSelf())

                .AddConnectSrc(o => o
                    .AddSelf()
                    .AddUri((baseUri, baseDomain) => $"wss://{baseDomain}:*"))

                // The generated hashes do nothing here, and we include it here only to show that generated hash values can be added to policies - script-src would generally be the policy where you use this technique.
                .AddDefaultSrc(o => o
                    .AddSelf()
                    .AddStrictDynamicIf(() => !builder.Environment.IsDevelopment())
                    .AddUnsafeInline()
                    .AddGeneratedHashValues(StaticFileExtension.CSS))

                .AddFontSrc(o => o.AddSelf())

                .AddFrameAncestors(o => o.AddNone())

                .AddFrameSrc(o => o.AddSelf())

                .AddFormAction(o => o.AddNone())

                .AddImgSrc(o => o
                    .AddSelf()  
                    .AddUri("www.google-analytics.com")
                    .AddUri("*.openstreetmap.org")
                    .AddSchemeSource(SchemeSource.Data, "w3.org/svg/2000"))

                .AddManifestSrc(o => o.AddSelf())

                .AddMediaSrc(o => o.AddSelf())

                .AddObjectSrc(o => o.AddNone())

                .AddReportUri(o => o.AddUri((baseUri, baseDomain) => $"https://{baseUri}/api/CspReporting/UriReport"))

                .AddScriptSrc(o => o
                    .AddSelf()
                    .AddNonce()
                    .AddHashValue(HashAlgorithm.SHA256, "v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=")
                    // StrictDynamic works on Chromium browsers but fails for both Firefox and Safari
                    //.AddStrictDynamicIf(() => !builder.Environment.IsDevelopment())
                    .AddReportSample()
                    .AddUri("https://www.googletagmanager.com/gtag/js")
                    .AddUri((baseUri, baseDomain) => $"https://{baseUri}/_framework/aspnetcore-browser-refresh.js")
                    .AddUri((baseUri, baseDomain) => $"https://{baseUri}/_framework/blazor.server.js")
                    .AddGeneratedHashValues(StaticFileExtension.JS))

                .AddStyleSrc(o => o
                    .AddSelf()
                    .AddUnsafeInline()
                    .AddUnsafeHashes()
                    .AddReportSample())

                .AddUpgradeInsecureRequests()

                .AddWorkerSrc(o => o.AddSelf());
        })
        .AddReferrerPolicy(ReferrerPolicyDirective.NoReferrer)
        .AddPermissionsPolicy("accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()")
        .AddStrictTransportSecurity(31536000, true)
        .AddXClientId("HttpSecurity.Example")
        .AddXContentTypeOptionsNoSniff()
        .AddXFrameOptionsDirective(XFrameOptionsDirective.Deny)
        .AddXXssProtectionDirective(XXssProtectionDirective.OneModeBlock)
        .AddXPermittedCrossDomainPoliciesDirective(XPermittedCrossDomainPoliciesDirective.None);
},
onStartingOptions =>
{
    onStartingOptions
        .AddCacheControl("public, max-age=86400")
        .AddExpires("0");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Added for debugging purposes - do not include this in your project
//app.Use(async (context, next) =>
//{
//    // Call the next delegate/middleware in the pipeline.
//    await next(context);
//});

app.UseHttpsRedirection();

app.UseHttpSecurityHeaders();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
