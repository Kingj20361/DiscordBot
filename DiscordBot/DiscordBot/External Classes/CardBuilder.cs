using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.External_Classes
{
    internal class CardBuilder
    {
        public int[] cardnumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, };
        public string[] cardsuits = { "Clubs", "Spades", "Diamonds", "Hearts" };

        public int SelectedNumber { get; internal set; }
        public string SelectedCard { get; internal set; }

        public CardBuilder()
        {
            var Random = new Random();
            int indexNumbers = Random.Next(0, this.cardnumbers.Length -1);
            int indexSuit = Random.Next(0, this.cardsuits.Length - 1);

            this.SelectedNumber = this.cardnumbers.ElementAt(indexNumbers);
            this.SelectedCard = this.cardnumbers.ElementAt(indexNumbers) + (" of ") + this.cardsuits.ElementAt(indexSuit);
        }


    }
}
