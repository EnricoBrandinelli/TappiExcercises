using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.interfacce
{
    public abstract class Instrument : ISoundMaker
    {
        public string Name { get; protected set; }

        public Instrument(string name)
        {
            Name = name;
        }

        public abstract string Play();
    }
}
