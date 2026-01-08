using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.interfacce
{
    public class Drum : Instrument
    {

        public Drum(string name): base ("drum")
        {

        }

        public override string Play()
        {
            return "tumtum";
        }
    }
}
