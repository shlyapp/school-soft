using SchoolSoft.ViewModel.Pages;
using System.Windows.Controls;

namespace SchoolSoft.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SubjectsPage.xaml
    /// </summary>
    public partial class SubjectsPage : Page
    {
        public SubjectsPage()
        {
            InitializeComponent();

            // Подключаем контекст к странице (биндинг данных)
            DataContext = new SubjectsViewModel();
        }
    }
}
