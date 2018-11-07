using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternDemoEvents
{
    /// <summary>
    /// Class with current weather.
    /// </summary>
    public class CurrentConditionsReport
    {
        /// <summary see cref="StatisticReport">
        /// Constructor registers this observer on event.
        /// </summary>
        /// <param name="weather">
        /// The manager of events.
        /// </param>
        public CurrentConditionsReport(WeatherManager weather)
        {
            weather.Weather += WeatherMessage;
        }

        /// <summary>
        /// Method unregisters this observer from event.
        /// </summary>
        /// <param name="weather">
        /// The manager of events.
        /// </param>
        public void Unregister(WeatherManager weather) => weather.Weather -= WeatherMessage;

        #region Private methods
        private void WeatherMessage(object sender, ChangingWeatherEventArgs eventArgs) => Console.WriteLine($"Current temperature: {eventArgs.Temperature}, current humidity: {eventArgs.Humidity}, current pressure: {eventArgs.Pressure}");
        #endregion
    }
}
