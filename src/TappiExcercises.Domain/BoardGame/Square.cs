using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class Square
    {
        
        public int Number { get; private set; }
        public int Malus { get; private set; }
        public bool IsTrap { get; private set; }


        public Square(int number, bool isTrap, int malus)
        {
            Number = number;
            Malus = malus;
            IsTrap = isTrap;
        }











    }
}
