using DSharpPlus;

var source = new CancellationTokenSource();

var discordClient = new DiscordClient(new DiscordConfiguration
{
    Token = "TOKEN",
    TokenType = TokenType.Bot
});

discordClient.MessageCreated += async (client, messageArgs) =>
{
    if (messageArgs.Message.Content.StartsWith("Hello"))
    {
        await discordClient.SendMessageAsync(messageArgs.Channel, $"Hello, {messageArgs.Author.Username}");
    }
};

var token = source.Token;

await discordClient.ConnectAsync();

while (!token.IsCancellationRequested)
{
    await Task.Delay(100);
}
