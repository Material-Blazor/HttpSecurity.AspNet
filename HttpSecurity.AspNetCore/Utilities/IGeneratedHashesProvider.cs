namespace HttpSecurity.AspNetCore;

/// <summary>
/// The interface for a provider of generated file hashes for CSP use.
/// </summary>
public interface IGeneratedHashesProvider
{
    /// <summary>
    /// Builds a <see cref="FileHashDataset"/> by listing inspecting static files.
    /// </summary>
    /// <returns></returns>
    public FileHashDataset GetFileHashDataset(IServiceProvider provider);

}
