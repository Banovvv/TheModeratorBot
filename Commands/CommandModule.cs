using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace TheModeratorBot.Commands
{
    public class CommandModule : BaseCommandModule
    {
        [Command("greet")]
        public async Task GreetCommand(CommandContext context)
        {
            await context.RespondAsync($"Greetings, {context.User.Username}!");
        }
    }
}
