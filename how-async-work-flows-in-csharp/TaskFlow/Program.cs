using TaskFlow;

using var client = new HttpClient();
client.DefaultRequestHeaders.UserAgent.ParseAdd("BlogCodeSample/1.0");

var users = new GitHubUserClient(client);
var user = await users.GetKnourianAsync(CancellationToken.None);

Console.WriteLine(user.Login);
