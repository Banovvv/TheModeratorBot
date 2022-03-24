using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace TheModeratorBot.Commands
{
    public class CommandModule : BaseCommandModule
    {
        [Command("greet")]
        public async Task GreetCommand(CommandContext context)
        {
            List<string> _Greetings = new List<string>()
            {
                $"Greetings, {context.User.Username}!",
                $"Hello, {context.User.Username}!",
                $"Hi there, {context.User.Username}!",
                $"Hey, {context.User.Username}!",
                $"How you doin', {context.User.Username} ;)"
            };

            await context.RespondAsync(_Greetings.OrderBy(x => Guid.NewGuid()).FirstOrDefault());
        }
        [Command("greet")]
        public async Task GreetCommand(CommandContext context, [RemainingText] string name)
        {
            List<string> _Greetings = new List<string>()
            {
                $"Greetings, {name}!",
                $"Hello, {name}!",
                $"Hi there, {name}!",
                $"Hey, {name}!",
                $"How you doin', {name} ;)"
            };

            await context.RespondAsync(_Greetings.OrderBy(x => Guid.NewGuid()).FirstOrDefault());
        }

        [Command("joke")]
        public async Task JokeCommand(CommandContext context)
        {
            List<string> _Jokes = new List<string>()
            {
                $"What’s the best thing about Switzerland?\nI don’t know, but the flag is a big plus.",
                $"I invented a new word!\nPlagiarism!",
                $"Did you hear about the mathematician who’s afraid of negative numbers?\nHe’ll stop at nothing to avoid them.",
                $"Why do we tell actors to “break a leg?”\nBecause every play has a cast.",
                $"Yesterday I saw a guy spill all his Scrabble letters on the road.\nI asked him, “What’s the word on the street?”",
                $"Have you heard about the new restaurant called Karma?\nThere’s no menu: You get what you deserve.",
                $"A bear walks into a bar and says, “Give me a whiskey and … cola.”\n“Why the big pause?” asks the bartender. The bear shrugged.\n“I’m not sure; I was born with them.”",
                $"Did you hear about the claustrophobic astronaut?\nHe just needed a little space.",
                $"Why don’t scientists trust atoms?\nBecause they make up everything.",
                $"How do you drown a hipster?\nThrow him in the mainstream.",
                $"What sits at the bottom of the sea and twitches?\nA nervous wreck.",
                $"Why can’t you explain puns to kleptomaniacs?\nThey always take things literally.",
                $"A man tells his doctor, “Doc, help me. I’m addicted to Twitter!”\nThe doctor replies, “Sorry, I don’t follow you…”",
                $"What do you call a parade of rabbits hopping backwards?\nA receding hare-line.",
                $"What’s the different between a cat and a comma?\nA cat has claws\nat the end of paws;\nA comma is a pause\nat the end of a clause.",
                $"What did the Buddhist say to the hot dog vendor?\nMake me one with everything."
            };

            await context.RespondAsync(_Jokes.OrderBy(x => Guid.NewGuid()).FirstOrDefault());
        }
    }
}
