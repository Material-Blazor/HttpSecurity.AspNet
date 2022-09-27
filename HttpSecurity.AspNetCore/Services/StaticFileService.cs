using Microsoft.AspNetCore.Hosting;
using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text;

namespace HttpSecurity.AspNetCore;

/// <summary>
/// The internal default implementation of <see cref="IGeneratedHashesProvider"/>, generating SHA512 hashes of all files recursively discovered in the environment's web root path.
/// </summary>
internal class StaticFileService : IGeneratedHashesProvider
{
    private readonly IWebHostEnvironment _env;

    public StaticFileService(IWebHostEnvironment env)
    {
        _env = env;
    }


    /// <inheritdoc/>
    public FileHashDataset GetFileHashDataset(IServiceProvider _)
    {
        var jsHashes = BuildHashes(Directory.GetFiles(_env.WebRootPath, "*.js", SearchOption.AllDirectories));
        var cssHashes = BuildHashes(Directory.GetFiles(_env.WebRootPath, "*.css", SearchOption.AllDirectories));

        return new()
        {
            FileHashes = jsHashes.Union(cssHashes).ToImmutableArray(),
        };
    }


    private static List<FileHash> BuildHashes(string[] paths)
    {
        List<FileHash> result = new();

        foreach (var path in paths)
        {
            result.Add(new() { FilePath = path, HashAlgorithm = HashAlgorithm.SHA512, HashValue = ComputeSha512Hash(path) });
        }

        return result;
    }


    private static string ComputeSha512Hash(string path)
    {
        return Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(File.ReadAllText(path))));
    }
}
