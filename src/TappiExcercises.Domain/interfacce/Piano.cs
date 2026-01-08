using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.interfacce
{
    public class Piano : Instrument
    {

        public Piano(string name) : base("Piano")
        {

        }

        public override string Play()
        {
            return "Swi";
        }
    }
}
