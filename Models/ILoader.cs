using System;
using System.Threading.Tasks;
namespace OilExtractionApp.Models;

public interface ILoader
{
    void LoadOil(string platformName);
    Task LoadOilAsync(string platformName); // Асинхронная версия
    bool IsLoading { get; } // Статус загрузки
    event EventHandler<LoadCompletedEventArgs> LoadCompleted; // Событие завершения загрузки
}

public class LoadCompletedEventArgs : EventArgs
{
    public string PlatformName { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public interface IEmergencyService
{
    void HandleEmergency(string emergencyType);
    bool IsEmergency { get; }
    event EventHandler<EmergencyEventArgs> EmergencyDeclared;
}

public class EmergencyEventArgs : EventArgs
{
    public string PlatformName { get; set; }
    public DateTime Time { get; set; }
    public string Message { get; set; }
}

public interface IPlatformMonitor
{
    void StartMonitoring();
    void StopMonitoring();
    PlatformStatus GetCurrentStatus();
}

public enum PlatformStatus
{
    Normal,
    Warning,
    Emergency,
    Maintenance
}