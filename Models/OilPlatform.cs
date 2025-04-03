using System;
namespace OilExtractionApp.Models;
public class OilPlatform
{
    public string Name { get; set; }
    public event EventHandler<FireEventArgs> FireEvent;

    private static Random _random = new Random();

    public void CheckForFire()
    {
        // С вероятностью 10% может произойти возгорание
        if (_random.Next(0, 100) < 10)
        {
            OnFire(new FireEventArgs { Message = $"{Name} возгорелась!" });
        }
    }

    protected virtual void OnFire(FireEventArgs e)
    {
        FireEvent?.Invoke(this, e);
    }
}

public class FireEventArgs : EventArgs
{
    public string Message { get; set; }
}
