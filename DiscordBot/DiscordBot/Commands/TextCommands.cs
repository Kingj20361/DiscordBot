using Discord;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class TextCommands : BaseCommandModule
    {
        [Command("poll")]
        public async Task CreatePollAsync(CommandContext ctx, string question, params string[] options)
        {
            // Check if there are at least 2 options
            if (options.Length < 2)
            {
                await ctx.RespondAsync("You must provide at least 2 options for the poll.");
                return;
            }

            // Build the poll embed
            var pollBuilder = new DiscordEmbedBuilder()
                .WithTitle("📊 " + question)
                .WithColor(DiscordColor.Blue);

            // Add the options as fields to the poll embed
            var optionList = new List<string>();
            for (int i = 0; i < options.Length && i < 10; i++)
            {
                string option = options[i];
                pollBuilder.AddField($"Option {i + 1} - {GetNumberEmoji(i + 1)}", option, inline: false);
                optionList.Add($"[{GetNumberEmoji(i + 1)}] {option}");
            }

            // Build the poll description using the option list
            string pollDescription = string.Join("\n", optionList);

            // Send the poll embed to the channel
            var pollMessage = await ctx.Channel.SendMessageAsync(pollDescription, embed: pollBuilder.Build());

            // Add the reaction options to the poll message
            for (int i = 0; i < options.Length && i < 10; i++)
            {
                DiscordEmoji emoji = DiscordEmoji.FromName(ctx.Client, GetNumberEmoji(i + 1));
                await pollMessage.CreateReactionAsync(emoji);
            }
        }

        private static string GetNumberEmoji(int number)
        {
            switch (number)
            {
                case 1: return ":one:";
                case 2: return ":two:";
                case 3: return ":three:";
                case 4: return ":four:";
                case 5: return ":five:";
                case 6: return ":six:";
                case 7: return ":seven:";
                case 8: return ":eight:";
                case 9: return ":nine:";
                case 10: return ":keycap_ten:";
                default: return "";
            }
        }

    }
}
