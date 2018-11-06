using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;
using System;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            StatisticReport statisticReport = new StatisticReport(weatherData);
            CurrentConditionsReport currentConditionsReport = new CurrentConditionsReport(weatherData);
            weatherData.Start(3000);
            Console.ReadKey();
        }
    }
}
