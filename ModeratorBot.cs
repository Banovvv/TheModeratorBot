using DSharpPlus;
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
            "whore",
            "rape",
            "gangbang"
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

            if (_ProfanityWords.Any(x => messageArgs.Message.Content.ToLower().Contains(x)))
            {
                if (_UsersWarned.Where(x => x == messageArgs.Author.Username).Count() == 0)
                {
                    await client.SendMessageAsync(messageArgs.Channel, $"Strike 1: We don't allow bad language here {messageArgs.Author.Mention}, play nice or you will be kicked out");
                    _UsersWarned.Add(messageArgs.Author.Username);
                }
                else if (_UsersWarned.Where(x => x == messageArgs.Author.Username).Count() == 1)
                {
                    await client.SendMessageAsync(messageArgs.Channel, $"Strike 2: {messageArgs.Author.Mention}, this is your second warnining - one more and you are out");
                    _UsersWarned.Add(messageArgs.Author.Username);
                }
                else if (_UsersWarned.Where(x => x == messageArgs.Author.Username).Count() == 2)
                {
                    // TODO: Kick repeating offenders
                    await client.SendMessageAsync(messageArgs.Channel, $"Strike 3: {messageArgs.Author.Mention} is kicked from the channel due to multiple violations!");
                    // Remove the user from the list of offenders
                    _UsersWarned = _UsersWarned.Where(x => x != messageArgs.Author.Username).ToList();
                }

                //List<string> messageParts = messageArgs.Message.Content.Split().ToList();

                //for (int i = 0; i < messageParts.Count; i++)
                //{
                //    if (_ProfanityWords.Any(x => messageParts[i].Contains(x)))
                //    {
                //        messageParts[i] = messageParts[i].Replace(messageParts[i], "*****");
                //    }
                //}

                //await messageArgs.Message.ModifyAsync(string.Join("", messageParts));
            }
        }
    }
}
