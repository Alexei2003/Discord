
using Discord;
using Newtonsoft.Json;

namespace HelloWorld
{
    class Program
    {

        static void Main(string[] args)
        {
            var discord = new DiscordBot();

            while (true)
            {
                Thread.Sleep(TimeSpan.FromDays(1));
                var a = discord.Equals(null);
            }

            /*            var str  = Console.ReadLine();

                        List<string> list = new List<string>();

                        while(str != "F")
                        {
                            list.Add(str);
                            str = Console.ReadLine();
                        }

                        Console.WriteLine(JsonConvert.SerializeObject(list));*/
        }
    }
}