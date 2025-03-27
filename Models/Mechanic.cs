using System;
namespace OilExtractionApp.Models;
public class Mechanic
{
    public string Name { get; set; }

    public void HandleFire(object sender, FireEventArgs e)
    {
        Console.WriteLine($"Механик {Name} реагирует на возгорание: {e.Message}");
    }
}
