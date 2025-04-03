using System;
using System.Threading.Tasks;

namespace OilExtractionApp.Models
{
    public interface ILoader
    {
        event Action<ILoader, string> LoadStarted;
        void LoadOil(string platformName);
        Task LoadOilAsync(string platformName);
        bool IsLoading { get; }
        event EventHandler<LoadCompletedEventArgs> LoadCompleted;
    }

    public class LoadCompletedEventArgs : EventArgs
    {
        public string PlatformName { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}