using OilExtractionApp.Models;

public class OilExtractionService
{
    private readonly OilPlatform _platform;
    private readonly ILoader _loader;
    private readonly Mechanic _mechanic;

    public OilExtractionService(OilPlatform platform, ILoader loader, Mechanic mechanic)
    {
        _platform = platform;
        _loader = loader;
        _mechanic = mechanic;
        _platform.FireEvent += _mechanic.HandleFire;
    }

    public void StartOilExtraction()
    {
        _platform.CheckForFire();
        _loader.LoadOil(_platform.Name);
    }
}