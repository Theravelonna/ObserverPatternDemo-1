using System;
using ObserverPatternDemoEvents;
using ObserverPatternDemoEvents.Observers;

namespace WeatherStationEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherManager = new WeatherManager();
            var currentConditionsReport = new CurrentConditionsReport(weatherManager);
            var statisticReport = new StatisticReport();
            statisticReport.Register(weatherManager);

            weatherManager.NewEvent();

            Console.ReadKey();
        }
    }
}
