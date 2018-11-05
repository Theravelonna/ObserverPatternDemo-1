using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            StatisticReport statisticReport = new StatisticReport();
            CurrentConditionsReport currentConditionsReport = new CurrentConditionsReport();
            weatherData.ShowChanging(3000);
            statisticReport.ShowData();
            //currentConditionsReport.ShowData();
        }
    }
}
