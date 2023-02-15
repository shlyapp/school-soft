using SchoolSoft.ViewModel.Pages;
using System.Windows.Controls;

namespace SchoolSoft.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();

            // Подключаем контекст к странице (биндинг данных)
            DataContext = new StudentsViewModel();
        }
    }
}
