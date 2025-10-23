using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain
{
    public class Student
    {


        private int Id { get; }
        private string Name { get; }
        private string Surname { get; }
        private string Class {  get; }

        List<Grade> _grades;
        HashSet<String> _subjects;

        public Student(int id, string name, string surname, string c)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Class = c;
            _grades = new List<Grade>();
        }

        public void AddGrade(double value, string subject)
        {
            _grades.Add(new Grade(value, subject));

        }

        private double GetAverage(string subject)
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
