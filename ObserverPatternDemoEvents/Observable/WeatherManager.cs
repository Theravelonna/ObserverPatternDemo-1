using System;
using System.Threading;

namespace ObserverPatternDemoEvents
{
    /// <summary>
    /// Class manages the event.
    /// </summary>
    public class WeatherManager
    {
        /// <summary>
        /// List events for changing weather.
        /// </summary>
        public event EventHandler<ChangingWeatherEventArgs> Weather = delegate { };

        protected virtual void OnChangingWeather(object e)
        {
            Weather?.Invoke(this, new ChangingWeatherEventArgs());
        }

        /// <summary>
        /// Method creates new event.
        /// </summary>
        public void NewEvent()
        {
            Timer work = new Timer(OnChangingWeather, null, 0, 2000);
        }
    }
}
