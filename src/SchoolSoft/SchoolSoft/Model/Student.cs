using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchoolSoft.Model
{
    /// <summary>
    /// Класс-модель ученика
    /// </summary>
    public class Student : INotifyPropertyChanged
    {
        // Описание всех свойств, присущих ученику

        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PatronymicName { get; set; }

        public string Place { get; set; }

        public string BirthdayData { get; set; }

        public Student(string Name, string Surname, string PatronymicName, string place, string birthdayData)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.PatronymicName = PatronymicName;
            Place = place;
            BirthdayData = birthdayData;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
