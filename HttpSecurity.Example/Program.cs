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
        .AddBaseUriPolicy(o => o.AddSelf())
        .AddBlockAllMixedContentPolicy()
        .AddChildSrcPolicy(o => o.AddSelf())
        .AddConnectSrcPolicy(o => o.AddSelf().AddUri("www.google-analytics.com").AddUri("region1.google-analytics.com")) // want to add wss://{baseDomain}:*
        .AddDefaultSrcPolicy(o => o.AddSelf())
        .AddFontSrcPolicy(o => o.AddUri("use.typekit.net").AddUri("fonts.googleapis.com").AddUri("fonts.gstatic.com"))
        .AddFrameAncestorsPolicy(o => o.AddNone())
        .AddFrameSrcPolicy(o => o.AddSelf())
        .AddFormActionPolicy(o => o.AddNone())
        .AddImgSrcPolicy(o => o.AddSelf().AddUri("www.google-analytics.com").AddUri("*.openstreetmap.org").AddSchemeSource(SchemeSource.Data, "w3.org/svg/2000"))
        .AddManifestSrcPolicy(o => o.AddSelf())
        .AddMediaSrcPolicy(o => o.AddSelf())
        .AddPrefetchSrcPolicy(o => o.AddSelf())
        .AddObjectSrcPolicy(o => o.AddNone()) // need report to and report uri, but both require base uri
        .AddScriptSrcPolicy(o => o.AddHashValue(HashAlgorithm.SHA256, "v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=").AddStrictDynamic().AddUnsafeInline().AddReportSample().AddUnsafeEval().AddUri("https://www.googletagmanager.com/gtag/js"))
        .AddStyleSrcPolicy(o => o.AddSelf().AddUnsafeInline().AddReportSample().AddUri("p.typekit.net").AddUri("use.typekit.net").AddUri("fonts.googleapis.com").AddUri("fonts.gstatic.com"))
        .AddUpgradeInsecureRequestsPolicy()
        .AddWorkerSrcPolicy(o => o.AddSelf());
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
