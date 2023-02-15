using SchoolSoft.ViewModel.Pages;
using System.Windows.Controls;

namespace SchoolSoft.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        public TeachersPage()
        {
            InitializeComponent();

            // Подключаем контекст к странице (биндинг данных)
            DataContext = new TeachersViewModel();
        }
    }
}
