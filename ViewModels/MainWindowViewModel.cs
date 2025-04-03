using System;
using System.Windows.Input;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using OilExtractionApp.Models;

namespace OilExtractionApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly OilExtractionService _oilExtractionService;
        private readonly IPlatformMonitor _platformMonitor;
        private string _statusMessage = "Система готова к работе.\n";
        private bool _isLoading;

        public MainWindowViewModel()
        {
            var platform = new OilPlatform { Name = "Платформа 1" };
            var mechanic = new Mechanic { Name = "Иван" };
            var loader = new OilLoader();

            _oilExtractionService = new OilExtractionService(platform, loader, mechanic);
            _platformMonitor = new PlatformMonitor(platform);

            StartExtractionCommand = new RelayCommand(StartExtraction, () => !IsLoading);
            StartMonitoringCommand = new RelayCommand(StartMonitoring);
            StopMonitoringCommand = new RelayCommand(StopMonitoring);
            ClearLogCommand = new RelayCommand(ClearLog);
            CloseCommand = new RelayCommand(Close);

            loader.LoadCompleted += (s, e) =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    StatusMessage += (e.IsSuccess ? "УСПЕХ: " : "ОШИБКА: ") + e.Message + "\n";
                    IsLoading = false;
                    ((RelayCommand)StartExtractionCommand).NotifyCanExecuteChanged();
                });
            };

            platform.FireEvent += (s, e) =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    StatusMessage += "ТРЕВОГА: " + e.Message + "\n";
                });
            };

            loader.LoadStarted += (s, platformName) =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    StatusMessage += $"Начата загрузка нефти с платформы {platformName}...\n";
                    IsLoading = true;
                    ((RelayCommand)StartExtractionCommand).NotifyCanExecuteChanged();
                });
            };
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand StartExtractionCommand { get; }
        public ICommand StartMonitoringCommand { get; }
        public ICommand StopMonitoringCommand { get; }
        public ICommand ClearLogCommand { get; }
        public ICommand CloseCommand { get; }

        private void StartExtraction()
        {
            try
            {
                _oilExtractionService.StartOilExtraction();
            }
            catch (Exception ex)
            {
                Dispatcher.UIThread.Post(() =>
                {
                    StatusMessage += $"ОШИБКА: {ex.Message}\n";
                });
            }
        }

        private void StartMonitoring()
        {
            _platformMonitor.StartMonitoring();
            StatusMessage += "Мониторинг платформы запущен\n";
        }

        private void StopMonitoring()
        {
            _platformMonitor.StopMonitoring();
            StatusMessage += "Мониторинг платформы остановлен\n";
        }

        private void ClearLog()
        {
            StatusMessage = "Журнал очищен.\nСистема готова к работе.\n";
        }

        private void Close()
        {
            // Реализация закрытия окна будет добавлена позже
        }
    }
}