using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class Student: Person
    {


       
        private string Class {  get; }

        List<Grade> _grades;
        HashSet<String> _subjects;

        public Student(int id, string name, string surname, string c):base(id,name,surname)
        {          
            Class = c;
            _grades = new List<Grade>();
        }

        public void AddGrade(double value, string subject)
        {
            _grades.Add(new Grade(value, subject));

        }

        public override string SayHello() => base.SayHello() + "Ciao prof!!";
       

        private void GetAverage(string subject)
        {
            double sum = 0;
            int counter = 0;

            for(int i = 0; i < _grades.Count; i++)
            {
                if (_grades[i].GetSubject() == subject)
                {
                    counter++;
                    sum = sum + _grades[i].GetValue();
                }

            }


        }
        
    }
}
