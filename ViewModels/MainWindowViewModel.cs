using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using OilExtractionApp.Models;

namespace OilExtractionApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly OilExtractionService _oilExtractionService;
        private readonly IPlatformMonitor _platformMonitor;
        private string _statusMessage;

        public MainWindowViewModel()
        {
            var platform = new OilPlatform { Name = "Платформа 1" };
            var mechanic = new Mechanic { Name = "Иван" };
            var loader = new OilLoader();

            _oilExtractionService = new OilExtractionService(platform, loader, mechanic);
            _platformMonitor = new PlatformMonitor(platform);

            StartExtractionCommand = new RelayCommand(StartExtraction);
            StartMonitoringCommand = new RelayCommand(StartMonitoring);
            StopMonitoringCommand = new RelayCommand(StopMonitoring);

            loader.LoadCompleted += (s, e) =>
                StatusMessage = e.IsSuccess ? e.Message : $"Ошибка: {e.Message}";

            platform.FireEvent += (s, e) =>
                StatusMessage = $"ТРЕВОГА: {e.Message}";
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public ICommand StartExtractionCommand { get; }
        public ICommand StartMonitoringCommand { get; }
        public ICommand StopMonitoringCommand { get; }

        private void StartExtraction()
        {
            _oilExtractionService.StartOilExtraction();
        }

        private void StartMonitoring()
        {
            _platformMonitor.StartMonitoring();
            StatusMessage = "Мониторинг платформы запущен";
        }

        private void StopMonitoring()
        {
            _platformMonitor.StopMonitoring();
            StatusMessage = "Мониторинг платформы остановлен";
        }
    }
}