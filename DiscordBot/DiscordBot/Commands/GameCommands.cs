using DiscordBot.External_Classes;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
         public class GameCommands : BaseCommandModule
                {
            [Command("draw")]

            public async Task SimpleCardGame(CommandContext ctx)
            {
                var UserCard = new CardBuilder();
                var userCardMessage = new DiscordMessageBuilder()
                    .WithEmbed(new DiscordEmbedBuilder()

                    .WithColor(DiscordColor.Blue)
                    .WithTitle("Your Card")
                    .WithDescription("You drew a: " + UserCard.SelectedCard)
                    );
                await ctx.Channel.SendMessageAsync(userCardMessage);
                var BotCard = new CardBuilder();
                var botCardMessage = new DiscordMessageBuilder()
                    .WithEmbed(new DiscordEmbedBuilder()

                    .WithColor(DiscordColor.Blue)
                    .WithTitle("Bots Card")
                    .WithDescription("The Bot drew a: " + BotCard.SelectedCard)
                    );

                await ctx.Channel.SendMessageAsync(botCardMessage);



                if (UserCard.SelectedNumber > BotCard.SelectedNumber)
                {
                    //The User Wins
                    var winningmessage = new DiscordEmbedBuilder()
                    {
                        Title = "You Win",
                        Color = DiscordColor.Red,
                        Description = "Congratulations"

                    };
                    await ctx.Channel.SendMessageAsync(embed: winningmessage);

                }
                else
                {
                    //The Bot wins
                    var Losingmessage = new DiscordEmbedBuilder()
                    {
                        Title = "You Lose",
                        Color = DiscordColor.Red,
                        Description = "Sorry"

                    };
                    await ctx.Channel.SendMessageAsync(embed: Losingmessage);
                }

            }
        }
    }

    


