using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class with statistic.
    /// </summary>
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> statistic;
        private WeatherInfo averageData;

        /// <summary see cref="StatisticReport">
        /// Constructor of class without parametrs.
        /// </summary>
        public StatisticReport()
        {
            statistic = new List<WeatherInfo>();
            averageData = new WeatherInfo();
        }

        /// <summary see cref="StatisticReport">
        /// Constructor of class with parametrs.
        /// </summary>
        /// <param name="observer">
        /// The observer.
        /// </param>
        public StatisticReport(IObservable<WeatherInfo> observer) : this()
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentNullException($"The {nameof(observer)} is null!");
            }
            
            observer.Register(this);
        }
        
        /// <summary>
        /// Method updates data in statistic.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="info">
        /// A new info.
        /// </param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            WeatherInfo newInfo = new WeatherInfo
            {
                Temperature = info.Temperature,
                Pressure = info.Pressure,
                Humidity = info.Humidity
            };

            statistic.Add(newInfo);

            CountAverage();
            Console.WriteLine(ShowData());
        }

        /// <summary>
        /// Method shows current values.
        /// </summary>
        /// <returns>
        /// <see cref="string"/> is data.
        /// </returns>
        public string ShowData()
        {
            return $"Average temperature: {averageData.Temperature}, average humidity: {averageData.Humidity}, average pressure: {averageData.Pressure}";
        }

        #region Private methods

        private delegate int ValueForSum(WeatherInfo value);

        private void CountAverage()
        {
            int countData = statistic.Count;
            int averageTemperature = Sum(tmp => tmp.Temperature) / countData;
            int averageHumidity = Sum(tmp => tmp.Humidity) / countData;
            int averagePressure = Sum(tmp => tmp.Pressure) / countData;

            averageData.Temperature = averageTemperature;
            averageData.Humidity = averageHumidity;
            averageData.Pressure = averagePressure;
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
