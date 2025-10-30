using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class Board
    {

        public List<Square> Squares { get; private set; }

        Random rnd = new Random();

        public Board()
        {

            Squares = new List<Square>();

        }

        public void GenerateBoard()
        {
            int counter = 0;

            for (int i = 0; i<100; i++)
            {
                
                int TrapGenerator = rnd.Next(0, 2);
               
                if(TrapGenerator == 1 && counter < 10)
                {
                    Squares.Add(new Square(i + 1, true, rnd.Next(1, 6)));
                    counter++;
                }
                else
                {

                    Squares.Add(new Square(i + 1, false, 0));

                }
            }

        }



    }
}
