using DSharpPlus;
using DSharpPlus.EventArgs;

namespace TheModeratorBot
{
    public class ModeratorBot
    {
        public void Initialize(DiscordClient client)
        {
            client.MessageCreated += OnMessageCreated;
        }

        private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs messageArgs)
        {
            if (messageArgs.Message.Content.StartsWith("Hello"))
            {
                await client.SendMessageAsync(messageArgs.Channel, $"Hello, {messageArgs.Author.Username}");
            }
        }
    }
}
