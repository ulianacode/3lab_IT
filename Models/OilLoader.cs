using System;
using System.Threading.Tasks;
namespace OilExtractionApp.Models;
public class OilLoader : ILoader
{
    public async void LoadOil(string platformName)
    {
        await Task.Delay(2000); // Simulate delay for oil loading
        Console.WriteLine($"{platformName} - нефть загружена!");
    }
}
