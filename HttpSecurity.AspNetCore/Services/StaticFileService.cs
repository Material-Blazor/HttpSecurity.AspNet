using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HttpSecurity.AspNetCore;

internal class StaticFileService
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<StaticFileService> _logger;

    public StaticFileService(IWebHostEnvironment env, ILogger<StaticFileService> logger)
    {
        _env = env;
        _logger = logger;
    }


    /// <summary>
    /// Builds a 
    /// </summary>
    /// <returns></returns>
    public FileHashDataset GetFileHashDataset()
    {
        var jsHashes = BuildHashes(Directory.GetFiles(_env.WebRootPath, "*.js", SearchOption.AllDirectories), StaticFileExtension.JS);
        var cssHashes = BuildHashes(Directory.GetFiles(_env.WebRootPath, "*.css", SearchOption.AllDirectories), StaticFileExtension.CSS);

        return new()
        {
            FileHashes = jsHashes.Union(cssHashes).ToImmutableArray(),
        };
    }


    private List<FileHash> BuildHashes(string[] paths, StaticFileExtension staticFileExtension)
    {
        List<FileHash> result = new();

        foreach (var path in paths)
        {
            result.Add(new() { FilePath = path, HashAlgorithm = HashAlgorithm.SHA256, HashValue = ComputeSha256Hash(path) });
        }

        return result;
    }


    private static string ComputeSha256Hash(string path)
    {
        return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(File.ReadAllText(path))));
    }
}
