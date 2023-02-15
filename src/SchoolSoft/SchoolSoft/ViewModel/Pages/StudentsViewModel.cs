using SchoolSoft.Database;
using SchoolSoft.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SchoolSoft.ViewModel.Pages
{
    /// <summary>
    /// ViewModel для страницы с учениками
    /// </summary>
    public class StudentsViewModel : INotifyPropertyChanged
    {
        // Текст из поискового запроса
        private string _filterText;

        // Данные, которые будут отображаться на странице
        public ObservableCollection<Student> Students { get; private set; }

        public StudentsViewModel()
        {
            Students = Data.Students;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string FilterText
        {
            get
            {
                return _filterText;
            }
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
            }
        }

        /// <summary>
        /// Фильтрация списка по поискову запросу
        /// </summary>
        public RelayCommand FilterListView
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ListView listView = obj as ListView;

                    if (String.IsNullOrEmpty(_filterText))
                    {
                        listView.ItemsSource = Data.Students;
                        return;
                    }

                    ObservableCollection<Student> students = new ObservableCollection<Student>();

                    string[] text = new string[3] { "", "", "" };
                    string[] splitText = _filterText.Split(' ');

                    for (int i = 0; i < splitText.Length; i++)
                    {
                        text[i] = splitText[i];
                    }

                    foreach (Student student in Data.Students.Where(x => (x.Name.ToLower() == text[0].ToLower() || String.IsNullOrEmpty(text[0])) &&
                                                                    (x.Surname.ToLower() == text[1].ToLower() || String.IsNullOrEmpty(text[1])) &&
                                                                    (x.PatronymicName.ToLower() == text[2].ToLower() || String.IsNullOrEmpty(text[2]))))
                    {
                        students.Add(student);
                    }

                    listView.ItemsSource = students;
                });
            }
        }
    }
}
