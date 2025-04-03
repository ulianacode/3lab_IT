namespace OilExtractionApp.Models
{
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
}