using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Trump
{
    public class Card
    {
        public Seed Seed { get; init; }
        public Rank Rank { get; init; }

        public Card(Seed seed, Rank rank)
        {
            Seed = seed;
            Rank = rank;
        }

        public int GetPoints()
        {
            int value;
            switch(Rank)
            {
                case Rank.Ace:
                    value = 11;
                    break;
                case Rank.Three:
                    value = 10;
                    break;
                case Rank.King:
                    value = 4;
                    break;
                case Rank.Knight:
                    value = 3;
                    break;
                case Rank.Jack:
                    value = 2;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }

        public bool CheckStrenght(Card card)
        {          
            return (int)Rank > (int)card.Rank;           
        }
    }
}
