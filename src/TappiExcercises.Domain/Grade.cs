namespace TappiExcercises.Domain
{
    public class Grade
    {

        private double _value;
        private string _subject; 

        public Grade(double value, string subject)
        {
            _value = value;
            _subject = subject;
            DateTime _date = DateTime.Now;

        }

        public string GetSubject() => _subject;
        public double GetValue() => _value;





    }
}
