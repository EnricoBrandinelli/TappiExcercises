using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Trump
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> Hand { get; private set; }
        public List<Card> WonCards { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            WonCards = new List<Card>();
        }

        public int GetAllPoints()
        {
            int points = 0;

            foreach(Card c in WonCards)
            {
                points += c.GetPoints();
            }
            return points;
        }

        public Card PlayCard(Random rnd)
        {
            int choice = rnd.Next(0, Hand.Count);
            Card chosencard = Hand[choice];
            Hand.Remove(chosencard);
            return chosencard;
        }
    }
}
