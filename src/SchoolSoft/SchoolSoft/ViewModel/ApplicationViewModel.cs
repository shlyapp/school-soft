using SchoolSoft.Model;
using SchoolSoft.View.Pages;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolSoft.ViewModel
{
    /// <summary>
    /// ViewModel главного окна
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // Поля для работы с анимацией
        private double _animationSpeed;
        private double _frameOpacity;

        // Текущая открытая страница
        private Page _currentPage;

        // Другие страницы
        private StudentsPage _studentsPage;
        private SubjectsPage _subjectsPage;
        private TeachersPage _teachersPage;

        // Для паттерна Singleton
        private static ApplicationViewModel _instanse;

        /// <summary>
        /// Анимация с медленным затуханием страницы
        /// </summary>
        /// <param name="page">Следующая страницы для показа</param>
        private async void SlowOpacityAmimation(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= _animationSpeed)
                {
                    FrameOpacity = i;
                    Thread.Sleep(20);
                }
                CurrentPage = page;
                for (double i = 0; i < 1.1; i += _animationSpeed)
                {
                    FrameOpacity = i;
                    Thread.Sleep(20);
                }
            });
        }

        /// <summary>
        /// Инициализация страниц
        /// </summary>
        private void LoadPages()
        {
            _studentsPage = new StudentsPage();
            _subjectsPage = new SubjectsPage();
            _teachersPage = new TeachersPage();
        }

        private ApplicationViewModel()
        {
            FrameOpacity = 1;
            _animationSpeed = 0.05;

            LoadPages();
            SlowOpacityAmimation(_subjectsPage);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static ApplicationViewModel GetInstance()
        {
            if (_instanse == null)
            {
                _instanse = new ApplicationViewModel();
            }

            return _instanse;
        }

        /// <summary>
        /// Текущая страницы
        /// </summary>
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            private set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        /// <summary>
        /// Прозрачность страницы для анимации
        /// </summary>
        public double FrameOpacity
        {
            get
            {
                return _frameOpacity;
            }
            private set
            {
                _frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }

        // Дальше идут команды для смены страниц: просто в зависимости от нажатой кнопки происходит анимация с переходом на нужную страницу

        public RelayCommand ShowStudentsPage
        {
            get
            {
                return new RelayCommand(obj => SlowOpacityAmimation(_studentsPage));
            }
        }

        public RelayCommand ShowSubjectsPage
        {
            get
            {
                return new RelayCommand(obj => SlowOpacityAmimation(_subjectsPage));
            }
        }

        public RelayCommand ShowTeachers
        {
            get
            {
                return new RelayCommand(obj => SlowOpacityAmimation(_teachersPage));
            }
        }
    }
}
