using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class with current weather.
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo info;

        /// <summary see cref="CurrentConditionsReport">
        /// Constructor of class.
        /// </summary>
        public CurrentConditionsReport()
        {
            info = new WeatherInfo();
        }

        /// <summary>
        /// Method updates data in this object.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="info">
        /// A new info.
        /// </param>
        private void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.info.Temperature = info.Temperature;
            this.info.Humidity = info.Humidity;
            this.info.Pressure = info.Pressure;
        }

        /// <summary>
        /// Method shows current values.
        /// </summary>
        public void ShowData()
        {
            string data = $"Temperature: {info.Temperature}, humidity: {info.Humidity}, pressure: {info.Pressure}";
            System.Console.WriteLine(data);
        }

        void IObserver<WeatherInfo>.Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            Update(sender, info);
        }
    }
}