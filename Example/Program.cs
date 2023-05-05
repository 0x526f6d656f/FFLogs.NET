using FFLogs.NET;
using FFLogs.NET.Options;

internal class Program {
    private static async Task Main() {
        var client = new FFLogsClient();
        await client.AuthenticateAsync(
            clientId: "asdf",
            clientSecret: "asdf"
        );

        // Proto-Carbuncle
        var test = await client.GetEncounterCharacterRankingsAsync(83);
    }
}