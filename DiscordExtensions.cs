using DSharpPlus;

namespace TheModeratorBot
{
    public static class DiscordExtensions
    {
        private static ModeratorBot? _Bot;
        public static DiscordClient AddModeratorBot(this DiscordClient client)
        {
            _Bot = new ModeratorBot();
            _Bot.Initialize(client);

            return client;
        }
    }
}
