using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class Person
    {
        public int Id { get; private set; }
        private string Name { get; set; } = string.Empty;
        private string Surname { get; set; } = string.Empty;

        public Person() { }

        public Person(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;

        }

        public virtual string SayHello() => "Buongiorno";

        




    }
}
