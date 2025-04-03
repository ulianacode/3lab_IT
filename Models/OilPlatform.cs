using System;

namespace OilExtractionApp.Models
{
    public class OilPlatform
    {
        public string Name { get; set; }
        public bool HasFire { get; private set; }
        public event EventHandler<FireEventArgs> FireEvent;

        private static readonly Random _random = new Random();

        public void CheckForFire()
        {
            // С вероятностью 10% может произойти возгорание
            if (_random.Next(0, 100) < 10)
            {
                HasFire = true;
                OnFire(new FireEventArgs { Message = $"{Name} возгорелась!" });
            }
            else
            {
                HasFire = false;
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
}