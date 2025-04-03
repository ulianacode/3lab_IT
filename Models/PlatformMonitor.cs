using System;
using System.Threading;

namespace OilExtractionApp.Models
{
    public class PlatformMonitor : IPlatformMonitor
    {
        private readonly OilPlatform _platform;
        private Timer _monitoringTimer;
        private PlatformStatus _currentStatus;

        public PlatformMonitor(OilPlatform platform)
        {
            _platform = platform;
            _currentStatus = PlatformStatus.Normal;
        }

        public void StartMonitoring()
        {
            _monitoringTimer = new Timer(_ => CheckPlatform(), null, 0, 5000);
        }

        public void StopMonitoring()
        {
            _monitoringTimer?.Dispose();
        }

        public PlatformStatus GetCurrentStatus()
        {
            return _currentStatus;
        }

        private void CheckPlatform()
        {
            _platform.CheckForFire();

            if (_platform.HasFire)
            {
                _currentStatus = PlatformStatus.Emergency;
            }
            else
            {
                _currentStatus = PlatformStatus.Normal;
            }
        }
    }
}