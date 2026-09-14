using System.Text.Json;

namespace TaskFlow;

public sealed class GitHubUserClient(HttpClient client)
{
    private const string KnourianUrl = "https://api.github.com/users/knourian";

    public GitHubUser GetKnourian(CancellationToken cancellationToken)
    {
        using var response = client.GetAsync(KnourianUrl, cancellationToken).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();

        var json = response.Content.ReadAsStringAsync(cancellationToken).GetAwaiter().GetResult();
        return Parse(json);
    }

    public async Task<GitHubUser> GetKnourianAsync(CancellationToken cancellationToken)
    {
        var json = await client.GetStringAsync(KnourianUrl, cancellationToken);
        return Parse(json);
    }

    public async Task<GitHubUser> GetKnourianForLibraryAsync(CancellationToken cancellationToken)
    {
        var json = await client
            .GetStringAsync(KnourianUrl, cancellationToken)
            .ConfigureAwait(false);

        return Parse(json);
    }

    private static GitHubUser Parse(string json) =>
        JsonSerializer.Deserialize<GitHubUser>(json)
        ?? throw new JsonException("The GitHub response did not contain a user.");
}
