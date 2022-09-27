using HttpSecurity.AspNetCore.Extensions;

namespace HttpSecurity.AspNetCore;

/// <summary>
/// A file's hash code used for building a CSP.
/// </summary>
public sealed class FileHashDataset
{
    private static char[] pathSeparators = { '/', '\\' };


    /// <summary>
    /// Internally generated unique id.
    /// </summary>
    internal readonly Guid Id = Guid.NewGuid();


    /// <summary>
    /// An enumerable of calculated file hashes.
    /// </summary>
    public IEnumerable<FileHash> FileHashes { get; init; } = Array.Empty<FileHash>();


    private Dictionary<StaticFileExtension, string> CspSubstingLookup { get; set; } = new();
    private Dictionary<string, string>? HashLookup { get; set; } = null;


    /// <summary>
    /// Returns a substring for the CSP containing hashes for the supplied file extension
    /// </summary>
    /// <param name="staticFileExtension"></param>
    /// <returns></returns>
    internal string GetCSPSubstring(StaticFileExtension staticFileExtension)
    {
        if (!CspSubstingLookup.TryGetValue(staticFileExtension, out var result))
        {
            result = "";

            foreach (var hash in FileHashes.Where(x => staticFileExtension.MatchesExtension(Path.GetExtension(x.FilePath).ToLower())))
            {
                result += " '" + hash.HashAlgorithm.ToString().ToLower() + "-" + hash.HashValue + "'";
            }

            CspSubstingLookup.Add(staticFileExtension, result);
        }

        return result;
    }


    /// <summary>
    /// Returns a hash string for CSP use.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    internal string GetHashString(string fileName)
    {
        HashLookup ??= FileHashes.Select(x => new KeyValuePair<string, string>(x.FilePath.Split(pathSeparators)[^1], x.GetHashString())).ToDictionary(x => x.Key, x => x.Value);

        HashLookup.TryGetValue(fileName, out var result);

        return result ?? "";
    }
}
