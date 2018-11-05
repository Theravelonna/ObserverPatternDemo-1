using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> statistic;
        private int averageTemperature;
        private int averageHumidity;
        private int averagePressure;

        public StatisticReport()
        {
            statistic = new List<WeatherInfo>();
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            statistic.Add(info);

            CountAverage();
        }

        public void ShowData()
        {
            string data = $"Average temperature: {averageTemperature}, average humidity: {averageHumidity}, average pressure: {averagePressure}";
            Console.WriteLine(data);
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
