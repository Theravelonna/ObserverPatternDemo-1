using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            StatisticReport statisticReport = new StatisticReport(weatherData);
            CurrentConditionsReport currentConditionsReport = new CurrentConditionsReport(weatherData);
            weatherData.Start(30);
            statisticReport.ShowData();
            currentConditionsReport.ShowData();
        }
    }
}
