# HttpSecurity.AspNet


---



[![NuGet release version](https://img.shields.io/nuget/v/HttpSecurity.AspNet?logo=nuget&label=nuget%20version&style=flat-square)](https://www.nuget.org/packages/HttpSecurity.AspNet/)
[![NuGet pre-release version](https://img.shields.io/nuget/vpre/HttpSecurity.AspNet?logo=nuget&label=nuget%20pre-release&style=flat-square)](https://www.nuget.org/packages/HttpSecurity.AspNet/)
[![NuGet downloads](https://img.shields.io/nuget/dt/HttpSecurity.AspNet?logo=nuget&label=nuget%20downloads&style=flat-square)](https://www.nuget.org/packages/HttpSecurity.AspNet/)


---


[![GitHub license](https://img.shields.io/badge/license-Apache%202-blue.svg)](https://raw.githubusercontent.com/material-blazor/HttpSecurity.AspNet/main/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/issues)
[![GitHub forks](https://img.shields.io/github/forks/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/network/members)
[![GitHub stars](https://img.shields.io/github/stars/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/stargazers)
[![GitHub watchers](https://img.shields.io/github/watchers/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/watchers)

---

[![GithubActionsRelease](https://img.shields.io/github/actions/workflow/status/Material-Blazor/HttpSecurity.AspNet/GithubActionsRelease.yml?label=actions%20release&logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/actions/workflows/GithubActionsRelease.yml)
[![GithubActionsWIP](https://img.shields.io/github/actions/workflow/status/Material-Blazor/HttpSecurity.AspNet/GithubActionsWIP.yml?label=actions%20wip&logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/actions/workflows/GithubActionsWIP.yml)

---




## Table of Contents
* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
* [Example](#example)

## About The Project
This package builds security policies for ASP.NET projects, including both Blazor Server and the server part of a Server Hosted Blazor WebAssembly project.
We would recommend cloning or forking this repo and see how the example Blazor Server project builds its security policies in 
[`Program.cs`](https://github.com/simonziegler/HttpSecurity.AspNet/blob/main/HttpSecurity.Example/Program.cs).

## Background

In general this package allows you to cleanly add a set of security headers to outgoing responses to requests for resources.
The best references for both the CSP and miscellaneous security headers is found in
the MDN documents starting [here](https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP).
An article specifically addressing ASP.Net Blazor is found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-7.0).

## Getting Started

### ASP.NET
- Add `builder.Services.AddHttpsSecurityHeaders()` in your `Program.cs` file, specifying the options that you require.
- Add `app.UseHttpSecurityHeaders();` with `app.UseCompressedStaticFiles();` in `Startup.Configure()`.
By default CompressedStaticFiles is configured to allow slightly larger files for some image formats as they can store more pixels per byte, this can be disabled by calling `builder.CompressedStaticFileOptions.RemoveImageSubstitutionCostRatio()`.

## Example
An example can be found in the [Example](https://github.com/material-blazor/HttpSecurity.AspNet/tree/main/HttpSecurity.Example) directory.

If you are running with a cloned repository you can remove the comment in _host.cshtml around "link rel='stylesheet' href='https://a.com/a.css'" to cause a security violation.
