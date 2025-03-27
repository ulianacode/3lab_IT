using System.Windows.Input;
using Avalonia.Input;  // Используем Avalonia.Input для команд
using CommunityToolkit.Mvvm.Input;  // Используем RelayCommand из CommunityToolkit.Mvvm
using OilExtractionApp.Models;  // Убедитесь, что у вас есть классы OilPlatform, Mechanic и OilLoader в этой папке

namespace OilExtractionApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly OilExtractionService _oilExtractionService;

        public MainWindowViewModel()
        {
            // Инициализация моделей и сервисов
            var platform = new OilPlatform { Name = "Платформа 1" };
            var mechanic = new Mechanic { Name = "Иван" };
            var loader = new OilLoader();  // Класс погрузчика
            _oilExtractionService = new OilExtractionService(platform, loader, mechanic);

            StartExtractionCommand = new RelayCommand(StartExtraction);  // Команда для запуска процесса
        }

        // Свойство для команды
        public ICommand StartExtractionCommand { get; }

        // Логика для начала добычи нефти
        private void StartExtraction()
        {
            _oilExtractionService.StartOilExtraction();
        }
    }
}
