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
        /// Constructor of class without parametrs.
        /// </summary>
        public CurrentConditionsReport()
        {
            info = new WeatherInfo();
        }

        /// <summary see cref="CurrentConditionsReport">
        /// Constructor of class with parametrs.
        /// </summary>
        /// <param name="observer">
        /// The observer.
        /// </param>
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
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.info.Temperature = info.Temperature;
            this.info.Humidity = info.Humidity;
            this.info.Pressure = info.Pressure;
        }

        /// <summary>
        /// Method shows current values.
        /// </summary>
        /// <returns>
        /// <see cref="string"/> is data.
        /// </returns>
        public string ShowData()
        {
            return $"Temperature: {info.Temperature}, humidity: {info.Humidity}, pressure: {info.Pressure}";
        }
    }
}