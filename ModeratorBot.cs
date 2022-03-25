using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace TheModeratorBot
{
    public class ModeratorBot
    {
        private List<string> _UsersWarned = new List<string>();
        private List<string> _ProfanityWords = new List<string>()
        {
            "fuck",
            "cunt",
            "asshole",
            "bitch",
            "dickhead",
            "dick",
            "whore"
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
                        
            if (_ProfanityWords.Any(x => message.Contains(x)))
            {
                await client.SendMessageAsync(messageArgs.Channel, $"We don't allow bad language here {messageArgs.Author.Mention}, play nice or you will be kicked out");

                _UsersWarned.Add(messageArgs.Author.Username);

                if(_UsersWarned.Where(x => x == messageArgs.Author.Username).Count() > 2)
                {
                    // TODO: Kick repeating offenders
                    await client.SendMessageAsync(messageArgs.Channel, $"{messageArgs.Author.Mention} is kicked from the channel due to multiple violations!");
                }

                //
                //List<string> messageParts = messageArgs.Message.Content.Split().ToList();

                //for (int i = 0; i < messageParts.Count; i++)
                //{
                //    if (_ProfanityWords.Any(x => messageParts[i].Contains(x)))
                //    {
                //        messageParts[i] = messageParts[i].Replace(messageParts[i], "*****");
                //    }
                //}

                //await messageArgs.Message.ModifyAsync(string.Join("", messageParts));
                //
            }
        }
    }
}
