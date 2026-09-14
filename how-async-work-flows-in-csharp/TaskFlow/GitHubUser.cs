using System.Text.Json.Serialization;

namespace TaskFlow;

public sealed record GitHubUser([property: JsonPropertyName("login")] string Login);
