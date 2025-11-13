using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class School
    {

        private List<Person> People { get; set; }

        public School()
        {
            People = new List<Person>();
        }

        public void AddStudent(string name, string surname, string c)
        {
            People.Add(new Student(People.Count + 1, name, surname, c));
        }

        public void AddTeacher(string name, string surname)
        {
            People.Add(new Teacher(People.Count + 1, name, surname));
        }

        public string AllGreeting()
        {
            string msg = string.Empty;
            for (int i = 0; i < People.Count; i++)
            {
                msg += People[i].SayHello() + "\n";
            }

            //Alternativa foreach. il foreach può solo leggere e non cambiare lo stato di qualcosa. il for può invece sia leggere che cambiare uno stato.
            //foreach (Person p in People)
            //{
            //    msg += p.SayHello() + "\n";
            //}

            //Alternativa 2
            //StringBuilder sb = new StringBuilder();
            //foreach(Person p in People)
            //{
            //    sb.AppendLine(p.SayHello());
            //}
            //return sb.ToString();

            return msg;

        }




    }
}
