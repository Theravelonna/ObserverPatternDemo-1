using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class with current weather.
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo info;
        private IObservable<WeatherInfo> observer;

        /// <summary see cref="CurrentConditionsReport">
        /// Constructor of class.
        /// </summary>
        public CurrentConditionsReport()
        {
            info = new WeatherInfo();
        }

        public CurrentConditionsReport(IObservable<WeatherInfo> observer) : this()
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentNullException($"The {nameof(observer)} is null!");
            }

            this.observer = observer;
            observer.Register(this);
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