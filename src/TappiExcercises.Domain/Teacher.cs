using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class Teacher : Person
    {

        public List<string> Subjects { get; private set; }

        public Teacher(int id, string name, string surname):base(id,name,surname)
        {
            Subjects = new List<string>();
        }

        public override string SayHello() => base.SayHello() + "Oggi Interrogo Dante su Dante A";

        public void AddSubject(string subject)
        {
            Subjects.Add(subject);
        }
       

    }
}
