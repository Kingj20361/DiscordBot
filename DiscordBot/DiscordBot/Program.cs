using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bot = new DiscordBot();
            bot.RunAsync().GetAwaiter().GetResult();

        }
    }
}
