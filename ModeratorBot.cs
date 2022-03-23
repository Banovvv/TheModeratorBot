using DSharpPlus;
using DSharpPlus.EventArgs;

namespace TheModeratorBot
{
    public class ModeratorBot
    {
        private HashSet<string> _UsersGreeted = new HashSet<string>();
        private HashSet<string> _UsersWarned = new HashSet<string>();

        private List<string> _ProfanityWords = new List<string>()
        {
            "fuck",
            "cunt",
            "asshole",
            "bitch",
            "dickhead",
            "dick"
        };

        public void Initialize(DiscordClient client)
        {
            client.MessageCreated += OnMessageCreated;
        }

        private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs messageArgs)
        {
            if (messageArgs.Author.Username == "TheModeratorBot")
            {
                return;
            }

            string message = messageArgs.Message.Content.ToLower();

            if (message.StartsWith("hello") || message.StartsWith("hi") || message.StartsWith("hey"))
            {
                if (_UsersGreeted.Contains(messageArgs.Author.Username))
                {
                    await client.SendMessageAsync(messageArgs.Channel, $"I've already greeted you {messageArgs.Author.Username}, stop looking for attention");
                }
                else
                {
                    _UsersGreeted.Add(messageArgs.Author.Username);

                    await client.SendMessageAsync(messageArgs.Channel, $"Hello, {messageArgs.Author.Username}"); 
                }
            }
            else if (_ProfanityWords.Any(x=>message.Contains(x)))
            {
                // TODO: Kick repeating offenders
                await client.SendMessageAsync(messageArgs.Channel, $"We don't allow bad language here {messageArgs.Author.Username}, play nice or you will be kicked out");
            }
        }
    }
}
