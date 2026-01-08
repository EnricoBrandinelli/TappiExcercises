using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.interfacce
{
    public class SoundMaker : Person
    {
        public SoundMaker(string name) : base(name)
        { }

        public string Play()
        {
            return "pam";
        }
    }
}
