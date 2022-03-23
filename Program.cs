using DSharpPlus;
using Microsoft.Extensions.Configuration;
using TheModeratorBot;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true)
                                              .Build();

var source = new CancellationTokenSource();

var discordClient = new DiscordClient(new DiscordConfiguration
{
    Token = configuration["discordToken"],
    TokenType = TokenType.Bot
});

discordClient.AddModeratorBot();

var token = source.Token;

await discordClient.ConnectAsync();

while (!token.IsCancellationRequested)
{
    await Task.Delay(100);
}
