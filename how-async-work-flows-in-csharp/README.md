# How async work flows in C#

Code for [How async work flows in C#](https://knourian.ir/en/posts/how-async-work-flows-in-csharp/).

It uses GitHub's public [`GET /users/knourian`](https://docs.github.com/en/rest/users/users#get-a-user) endpoint to contrast a blocking call with `Task`, `async`, `await`, and a library-oriented `ConfigureAwait(false)` method. The endpoint accepts unauthenticated requests; the program supplies only a `User-Agent` header.

```bash
dotnet run --project TaskFlow
```
