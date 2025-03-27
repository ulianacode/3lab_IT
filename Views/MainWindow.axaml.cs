using Avalonia.Controls;

namespace OilExtractionApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();  // Убедитесь, что ViewModel существует и правильно используется
        }
    }
}
