using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.interfacce
{
    public class Orchestra
    {
        public List<Instrument> Instruments { get; private set; }

        public Orchestra()
        {
            Instruments = new List<Instrument>();
        }

        public void AddDrum(Drum d)
        {
            Instruments.Add(d);
        }

        public void AddPiano(Piano p)
        {
            Instruments.Add(p);
        }

        public void AddPiano(SoundMaker p)
        {
            Instruments.Add(p);
        }

        public void PlayAll()
        {
            foreach(Instrument i in Instruments)
            {
                i.Play();
            }
        }
    }
}
