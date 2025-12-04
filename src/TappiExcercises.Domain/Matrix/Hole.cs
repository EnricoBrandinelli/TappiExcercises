using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Matrix
{
    public class Hole
    {
        public int Lenght { get; private set; }
        public int OffSet { get; private set; }

        public Hole(int lenght, int offset)
        {
            Lenght = lenght;
            OffSet = offset;
        }
    }
}
