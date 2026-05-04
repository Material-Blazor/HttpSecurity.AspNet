# HttpSecurity.AspNet — AI Development Guide

> Open-source ASP.NET class library for HTTP security headers and Content Security Policy

---

## Quick Reference

| Item             | Value                                              |
| :--------------- | :------------------------------------------------- |
| **Framework**    | .NET 8.0 (`net8.0`) — runs on .NET 8, 9, 10       |
| **Build**        | `dotnet build HttpSecurity.AspNet.slnx`            |
| **Pack**         | `dotnet pack HttpSecurity.AspNet/HttpSecurity.AspNet.csproj` |
| **Source gen**   | `SourceGenerator/` targets `netstandard2.0`        |

---

## Project Architecture

| Project                  | Purpose                                            | TFM               |
| :----------------------- | :------------------------------------------------- | :---------------- |
| **HttpSecurity.AspNet**  | Library: CSP, headers, SRI hash generation         | `net8.0`          |
| **SourceGenerator**      | Roslyn source generator for hash computation       | `netstandard2.0`  |
| **HttpSecurity.Example** | Example Blazor Server app                          | `net8.0`          |

---

## C# Standards

- `ImplicitUsings=enable`, `Nullable=enable`
- Interfaces: `I` prefix
- Types, properties, methods: PascalCase
- File-scoped namespaces
- Expression-bodied members where appropriate
- Null-coalescing (`??`) and null-propagation (`?.`) preferred
