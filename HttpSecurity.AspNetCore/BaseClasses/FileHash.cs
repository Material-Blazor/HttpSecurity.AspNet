namespace HttpSecurity.AspNetCore;

/// <summary>
/// A file's hash code used for building a CSP.
/// </summary>
public sealed class FileHash
{
    /// <summary>
    /// The file's path.
    /// </summary>
    public string FilePath { get; init; } = "";


    /// <summary>
    /// The applied hashing alorithm.
    /// </summary>
    public HashAlgorithm HashAlgorithm { get; init; }


    /// <summary>
    /// The file's hash code.
    /// </summary>
    public string HashValue { get; init; } = "";


    /// <summary>
    /// Returns a hash string for CSP use.
    /// </summary>
    /// <returns></returns>
    public string GetHashString()
    {
        return HashAlgorithm.ToString().ToLower() + "-" + HashValue; 
    }
}
