using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchoolSoft.Model
{
    /// <summary>
    /// Класс-модель предмета
    /// </summary>
    public class Subject : INotifyPropertyChanged
    {
        // Свойства, присущие предмету

        public int ID { get; set; }

        public string Name { get; set; }

        public Subject(string Name)
        {
            this.Name = Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
