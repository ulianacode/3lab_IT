using OilExtractionApp.Models;

public class OilExtractionService
{
    private readonly OilPlatform _platform;
    private readonly ILoader _loader;
    private readonly Mechanic _mechanic;
    private OilPlatform platform;
    private OilLoader loader;
    private Mechanic mechanic;

    public OilExtractionService(OilPlatform platform, ILoader loader, Mechanic mechanic)
    {
        _platform = platform;
        _loader = loader;
        _mechanic = mechanic;
        _platform.FireEvent += _mechanic.HandleFire; // Подписка на событие возгорания
    }

    public OilExtractionService(OilPlatform platform, OilLoader loader, Mechanic mechanic)
    {
        this.platform = platform;
        this.loader = loader;
        this.mechanic = mechanic;
    }

    public void StartOilExtraction()
    {
        // Проверка на возгорание
        _platform.CheckForFire();

        // Отправка нефти погрузчиком
        _loader.LoadOil(_platform.Name);
    }
}
