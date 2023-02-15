using SchoolSoft.ViewModel;
using System.Windows;

namespace SchoolSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Подключаем контекст к странице (биндинг данных)
            DataContext = ApplicationViewModel.GetInstance();
        }
    }
}
