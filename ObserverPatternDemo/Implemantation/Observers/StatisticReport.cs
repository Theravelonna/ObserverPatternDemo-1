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
        public StatisticReport(IObservable<WeatherInfo> sender) : this()
        {
            ValidationData(sender);

            sender.Register(this);
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
            ValidationData(sender, info);

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

        private void ValidationData(IObservable<WeatherInfo> sender)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentNullException($"The {nameof(sender)} is null!");
            }
        }

        private void ValidationData(WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException($"The {nameof(info)} is null!");
            }
        }

        private void ValidationData(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            ValidationData(sender);
            ValidationData(info);
        }
        #endregion
    }
}
