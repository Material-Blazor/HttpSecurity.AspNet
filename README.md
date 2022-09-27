# HttpSecurity.AspNet


---



[![NuGet version](https://img.shields.io/nuget/v/HttpSecurity.AspNet?logo=nuget&label=nuget%20version&style=flat-square)](https://www.nuget.org/packages/HttpSecurity.AspNet/)
[![NuGet version](https://img.shields.io/nuget/vpre/HttpSecurity.AspNet?logo=nuget&label=nuget%20pre-release&style=flat-square)](https://www.nuget.org/packages/HttpSecurity.AspNet/)
[![NuGet downloads](https://img.shields.io/nuget/dt/HttpSecurity.AspNet?logo=nuget&label=nuget%20downloads&style=flat-square)](https://www.nuget.org/packages/HttpSecurity.AspNet/)


---


[![GitHub license](https://img.shields.io/badge/license-Apache%202-blue.svg)](https://raw.githubusercontent.com/material-blazor/HttpSecurity.AspNet/main/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/issues)
[![GitHub forks](https://img.shields.io/github/forks/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/network/members)
[![GitHub stars](https://img.shields.io/github/stars/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/stargazers)
[![GitHub stars](https://img.shields.io/github/watchers/Material-Blazor/HttpSecurity.AspNet?logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/watchers)

---

[![GithubActionsMainPublish](https://img.shields.io/github/workflow/status/Material-Blazor/HttpSecurity.AspNet/GithubActionsRelease?label=actions%20release&logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/actions?query=workflow%3AGithubActionsRelease)
[![GithubActionsDevelop](https://img.shields.io/github/workflow/status/Material-Blazor/HttpSecurity.AspNet/GithubActionsWIP?label=actions%20wip&logo=github&style=flat-square)](https://github.com/Material-Blazor/HttpSecurity.AspNet/actions?query=workflow%3AGithubActionsWIP)

---




## Table of Contents
* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
* [Example](#example)

## About The Project
This package builds security policies for ASP.NET projects, including both Blazor Server and the server part of a Server Hosted Blazor WebAssembly project. We intend to build
and deploy a documentation website shortly. Until then fork this repo and see how the example Blazor Server project builds its security policies in 
[`Program.cs`](https://github.com/simonziegler/HttpSecurity.AspNet/blob/main/HttpSecurity.Example/Program.cs).

## Getting Started

### ASP.NET
- Add `builder.Services.AddHttpsSecurityHeaders()` in your `Program.cs` file, specifying the options that you require.
- Add `UseHttpSecurityHeaders();` with `UseCompressedStaticFiles();` in `Startup.Configure()`.
By default CompressedStaticFiles is configured to allow slightly larger files for some image formats as they can store more pixels per byte, this can be disabled by calling `CompressedStaticFileOptions.RemoveImageSubstitutionCostRatio()`.

## Example
An example can be found in the [Example](https://github.com/material-blazor/HttpSecurity.AspNet/tree/main/HttpSecurity.Example) directory.
