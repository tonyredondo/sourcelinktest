using System.Reflection;

var (repo, sha) = GetGitMetadata(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
Console.WriteLine("Repository: {0}", repo);
Console.WriteLine("Commit: {0}", sha);

(string? repositoryUrl, string? commitSha) GetGitMetadata(Assembly assembly)
{
    string? repositoryUrl = null;
    string? commitSha = null;
    foreach (var attribute in assembly.GetCustomAttributes())
    {
        switch (attribute)
        {
            case AssemblyMetadataAttribute { Key: "RepositoryUrl" } amAttr:
                repositoryUrl = amAttr.Value;
                break;
            case AssemblyInformationalVersionAttribute { InformationalVersion: { } informationalVersion }:
            {
                var plusIndex = informationalVersion.IndexOf("+", StringComparison.Ordinal);
                if (plusIndex != -1)
                {
                    commitSha = informationalVersion.Substring(plusIndex + 1);
                }

                break;
            }
        }

        if (repositoryUrl != null && commitSha != null)
        {
            break;
        }
    }

    return (repositoryUrl, commitSha);
}