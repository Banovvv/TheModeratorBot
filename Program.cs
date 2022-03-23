using DSharpPlus;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true)
                                              .Build();

var source = new CancellationTokenSource();

var discordClient = new DiscordClient(new DiscordConfiguration
{
    Token = configuration["discordToken"],
    TokenType = TokenType.Bot
});

var token = source.Token;

await discordClient.ConnectAsync();

while (!token.IsCancellationRequested)
{
    await Task.Delay(100);
}
