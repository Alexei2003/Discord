using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using System.Windows.Input;

namespace Discord
{
    internal class DiscordBot
    {
        private readonly DiscordSocketClient discord = new();
        private readonly CommandService command = new();

        private readonly Random rand = new Random();

        private readonly List<string> messagePrinzEugen;

        public DiscordBot()
        {
            var accessToken = File.ReadAllText("AccessToken.txt");

            var str = File.ReadAllText("PrinzEugen.txt");
            messagePrinzEugen = JsonConvert.DeserializeObject<List<string>>(str);

            discord.LoginAsync(TokenType.Bot, accessToken);
            discord.StartAsync();

            discord.MessageReceived += HandleCommandAsync;

            Task.Delay(-1);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {

            var message = messageParam as SocketUserMessage;
            if (message == null || message.Author.IsBot)
            {
                return;
            }

            var context = new SocketCommandContext(discord, message);

            command.ExecuteAsync(context, 0, null);

            if (rand.Next(5) == 0)
            {
                context.Channel.SendMessageAsync(messagePrinzEugen[rand.Next(rand.Next(messagePrinzEugen.Count))]);
            }
        }
    }
}
