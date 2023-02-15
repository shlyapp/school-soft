using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchoolSoft.Model
{
    /// <summary>
    /// Класс-модель учителя
    /// </summary>
    public class Teacher : INotifyPropertyChanged
    {
        // Свойства, присущие учителю

        // Список предметов, которые преподает учитель
        // В БД просто в таблице Subjects вписать TeacherID нужный и предмет отобразиться у учителя
        private List<Subject> _subjects;

        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PatronymicName { get; set; }

        public string Place { get; set; }

        public string BirthdayDate { get; set; }

        public List<Subject> Subjects
        {
            get { return _subjects; }
            private set
            {
                _subjects = value;
            }
        }

        public Teacher(string Name, string Surname, string PatronymicName, string place, string birthdayDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.PatronymicName = PatronymicName;
            Place = place;
            BirthdayDate = birthdayDate;


            _subjects = new List<Subject>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
