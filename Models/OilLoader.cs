using System;
using System.Threading.Tasks;
using System.Threading.Tasks;
namespace OilExtractionApp.Models;

public class OilLoader : ILoader
{
    public bool IsLoading { get; private set; }
    public event EventHandler<LoadCompletedEventArgs> LoadCompleted;

    public async void LoadOil(string platformName)
    {
        await LoadOilAsync(platformName);
    }

    public async Task LoadOilAsync(string platformName)
    {
        IsLoading = true;
        try
        {
            await Task.Delay(2000); // Имитация загрузки
            LoadCompleted?.Invoke(this, new LoadCompletedEventArgs
            {
                PlatformName = platformName,
                IsSuccess = true,
                Message = $"{platformName} - нефть успешно загружена!"
            });
        }
        catch
        {
            LoadCompleted?.Invoke(this, new LoadCompletedEventArgs
            {
                PlatformName = platformName,
                IsSuccess = false,
                Message = $"{platformName} - ошибка загрузки нефти!"
            });
        }
        finally
        {
            IsLoading = false;
        }
    }
}