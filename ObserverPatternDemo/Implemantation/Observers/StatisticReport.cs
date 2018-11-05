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
        private int averageTemperature;
        private int averageHumidity;
        private int averagePressure;
        private IObservable<WeatherInfo> observer;

        /// <summary see cref="StatisticReport">
        /// Constructor of class without parametrs.
        /// </summary>
        public StatisticReport()
        {
            statistic = new List<WeatherInfo>();
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

            this.observer = observer;
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
            statistic.Add(info);

            CountAverage();
        }

        /// <summary>
        /// Method shows current values.
        /// </summary>
        /// <returns>
        /// <see cref="string"/> is data.
        /// </returns>
        public string ShowData()
        {
            return $"Average temperature: {averageTemperature}, average humidity: {averageHumidity}, average pressure: {averagePressure}";
        }

        #region Private methods
        void IObserver<WeatherInfo>.Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            Update(sender, info);
        }

        private delegate int ValueForSum(WeatherInfo value);

        private void CountAverage()
        {
            int countData = statistic.Count;
            averageTemperature = Sum((info) => (info.Temperature)) / countData;
            averageHumidity = Sum((info) => (info.Humidity)) / countData;
            averagePressure = Sum((info) => (info.Pressure)) / countData;
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
