using System;
using System.Collections.Generic;

namespace ObserverPatternDemoEvents.Observers
{
    /// <summary>
    /// Class with statistic.
    /// </summary>
    public class StatisticReport
    {
        private List<ChangingWeatherEventArgs> statistic;
        private int averageTemperature;
        private int averageHumidity;
        private int averagePressure;

        /// <summary see cref="StatisticReport">
        /// Constructor of class without parametrs.
        /// </summary>
        public StatisticReport()
        {
            statistic = new List<ChangingWeatherEventArgs>();
        }

        /// <summary>
        /// Method registers this observer on event.
        /// </summary>
        /// <param name="weather">
        /// The manager of events.
        /// </param>
        public void Register(WeatherManager weather)
        {
            weather.Weather += StatisticWeatherMessage;
        }

        /// <summary>
        /// Method unregisters this observer from event.
        /// </summary>
        /// <param name="weather">
        /// The manager of events.
        /// </param>
        public void Unregister(WeatherManager weather) => weather.Weather -= StatisticWeatherMessage;

        #region Private methods
        private void StatisticWeatherMessage(object sender, ChangingWeatherEventArgs eventArgs)
        {
            ChangingWeatherEventArgs newEventArgs = new ChangingWeatherEventArgs
            {
                Temperature = eventArgs.Temperature,
                Pressure = eventArgs.Pressure,
                Humidity = eventArgs.Humidity
            };

            statistic.Add(newEventArgs);

            CountAverage();

            Console.WriteLine($"Average temperature: {averageTemperature}, average humidity: {averageHumidity}, average pressure: {averagePressure}");
        }

        private delegate int ValueForSum(ChangingWeatherEventArgs value);

        private void CountAverage()
        {
            int countData = statistic.Count;
            averageTemperature = Sum(tmp => tmp.Temperature) / countData;
            averageHumidity = Sum(tmp => tmp.Humidity) / countData;
            averagePressure = Sum(tmp => tmp.Pressure) / countData;
        }

        private int Sum(ValueForSum valueForSum)
        {
            int sum = 0;

            foreach (var value in statistic)
            {
                sum += valueForSum(value);
            }

            return sum;
        }
        #endregion
    }
}
