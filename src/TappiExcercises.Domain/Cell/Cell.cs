using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Cell
{
    public class Cell
    {
        private int Val;

        public Cell(int v)
        {
            Val = v;
        }

        public Cell():this(0)
        {
            
        }

        public int getVal() => Val;

        public virtual void SetVal(int v) { Val = v; }

        public virtual void Clear() { Val = 0; }
    }
}
