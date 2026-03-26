using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Trump
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
            for(int s = 0; s<4; s++)
            {
                for(int r = 1; r<11; r++)
                {
                    Cards.Add(new Card((Seed)s, (Rank)r));
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            int flag;
            for(int i = 0; i<=100; i++)
            {
                int pos1 = rnd.Next(0, 39);
                int pos2 = rnd.Next(0, 39);
                if (pos1 != pos2)
                {
                    flag = pos1;
                    pos1 = pos2;
                    pos2 = flag;
                }
                else
                    i -= 1;
            }
        }

        public Card Draw()
        {
            Card card = Cards[Cards.Count - 1];
            Cards.Remove(card);
            return card;
        }
    }
}
