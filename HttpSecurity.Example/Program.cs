using HttpSecurity.AspNetCore;
using HttpSecurity.Example.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddContentSecurityPolicy(options => 
{
    options
        .AddBaseUriCSP(o => o.AddSelf())
        .AddBlockAllMixedContentCSP()
        .AddChildSrcCSP(o => o.AddSelf())
        .AddConnectSrcCSP(o => o.AddSelf().AddUri((baseUri, baseDomain) => $"wss://{baseDomain}:*").AddUri("www.google-analytics.com").AddUri("region1.google-analytics.com"))
        .AddDefaultSrcCSP(o => o.AddSelf())
        .AddFontSrcCSP(o => o.AddUri("use.typekit.net").AddUri("fonts.googleapis.com").AddUri("fonts.gstatic.com"))
        .AddFrameAncestorsCSP(o => o.AddNone())
        .AddFrameSrcCSP(o => o.AddSelf())
        .AddFormActionCSP(o => o.AddNone())
        .AddImgSrcCSP(o => o.AddSelf().AddUri("www.google-analytics.com").AddUri("*.openstreetmap.org").AddSchemeSource(SchemeSource.Data, "w3.org/svg/2000"))
        .AddManifestSrcCSP(o => o.AddSelf())
        .AddMediaSrcCSP(o => o.AddSelf())
        .AddPrefetchSrcCSP(o => o.AddSelf())
        .AddObjectSrcCSP(o => o.AddNone())
        .AddReportUriCSP(o => o.AddUri((baseUri, baseDomain) => $"https://{baseUri}/api/CspReporting/UriReport"))
        .AddScriptSrcCSP(o => o.AddHashValue(HashAlgorithm.SHA256, "v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=").AddStrictDynamic().AddUnsafeInline().AddReportSample().AddUnsafeEval().AddUri("https://www.googletagmanager.com/gtag/js"))
        .AddStyleSrcCSP(o => o.AddSelf().AddUnsafeInline().AddReportSample().AddUri("p.typekit.net").AddUri("use.typekit.net").AddUri("fonts.googleapis.com").AddUri("fonts.gstatic.com"))
        .AddUpgradeInsecureRequestsCSP()
        .AddWorkerSrcCSP(o => o.AddSelf());
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

app.UseStaticFiles();

app.UseContentSecurityPolicy();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
