using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Configuration;
using TheModeratorBot.Extensions;
using TheModeratorBot.Commands;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .Build();

var source = new CancellationTokenSource();

var discordClient = new DiscordClient(new DiscordConfiguration
{
    Token = configuration["discordToken"],
    TokenType = TokenType.Bot
});

var commandModule = discordClient.UseCommandsNext(new CommandsNextConfiguration()
{
    StringPrefixes = new string[] { "!" }
});

commandModule.RegisterCommands<CommandModule>();

discordClient.AddModeratorBot();

var token = source.Token;

await discordClient.ConnectAsync();

while (!token.IsCancellationRequested)
{
    await Task.Delay(100);
}
