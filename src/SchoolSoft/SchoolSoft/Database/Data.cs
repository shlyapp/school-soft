using SchoolSoft.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolSoft.Database
{
    /// <summary>
    /// Данные из базы данных
    /// </summary>
    public class Data
    {
        static private ApplicationContex data;

        static public ObservableCollection<Student> Students { get; private set; }
        static public ObservableCollection<Subject> Subjects { get; private set; }
        static public ObservableCollection<Teacher> Teachers { get; private set; }

        static Data()
        {
            // Контекст базы данных
            data = new ApplicationContex();

            // Подключение
            data.Database.EnsureCreated();

            // Выкачиваем данные и преобразуем в ObservableCollection
            Students = new ObservableCollection<Student>();
            Subjects = new ObservableCollection<Subject>();
            Teachers = new ObservableCollection<Teacher>();

            foreach (Student student in data.Students.ToList())
            {
                Students.Add(student);
            }

            foreach (Subject subject in data.Subjects.ToList())
            {
                Subjects.Add(subject);
            }

            foreach (Teacher teacher in data.Teachers.ToList())
            {
                Teachers.Add(teacher);
            }
        }
    }
}
