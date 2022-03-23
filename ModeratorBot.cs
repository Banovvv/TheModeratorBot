using DSharpPlus;
using DSharpPlus.EventArgs;

namespace TheModeratorBot
{
    public class ModeratorBot
    {
        private HashSet<string> _UsersGreeted = new HashSet<string>();
        public void Initialize(DiscordClient client)
        {
            client.MessageCreated += OnMessageCreated;
        }

        private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs messageArgs)
        {
            if (messageArgs.Message.Content.StartsWith("Hello"))
            {
                if (_UsersGreeted.Contains(messageArgs.Author.Username))
                {
                    await client.SendMessageAsync(messageArgs.Channel, $"I've already greeted you {messageArgs.Author.Username}, stop looking for attention");
                }
                else
                {
                    await client.SendMessageAsync(messageArgs.Channel, $"Hello, {messageArgs.Author.Username}"); 
                }
            }
        }
    }
}
