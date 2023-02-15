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
    /// ViewModel для страницы с предметами
    /// </summary>
    public class SubjectsViewModel : INotifyPropertyChanged
    {
        // Текст из поискового запроса
        private String _filterText;

        // Данные, которые будут отображаться на странице
        public ObservableCollection<Subject> Subjects { get; private set; }

        public SubjectsViewModel()
        {
            Subjects = Data.Subjects;
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
                        listView.ItemsSource = Data.Subjects;
                        return;
                    }

                    ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();

                    foreach (Subject subject in Data.Subjects.Where(x => x.Name.ToLower() == _filterText.ToLower()))
                    {
                        subjects.Add(subject);
                    }

                    listView.ItemsSource = subjects;
                });
            }
        }
    }
}
