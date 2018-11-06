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
        public CurrentConditionsReport(IObservable<WeatherInfo> sender) : this()
        {
            ValidationData(sender);

            sender.Register(this);
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
            ValidationData(sender, info);

            this.info.Temperature = info.Temperature;
            this.info.Humidity = info.Humidity;
            this.info.Pressure = info.Pressure;

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
            return $"Temperature: {info.Temperature}, humidity: {info.Humidity}, pressure: {info.Pressure}";
        }

        #region Private methods
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