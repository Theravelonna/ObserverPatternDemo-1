using System;
using System.Threading;

namespace ObserverPatternDemoEvents
{
    /// <summary>
    /// Class with events changing weather.
    /// </summary>
    public class ChangingWeatherEventArgs : EventArgs
    {
        private Random sensor;

        /// <summary>
        /// Public property with temperature.
        /// </summary>
        public int Temperature { get; set; }
        
        /// <summary>
        /// Public property with humidity.
        /// </summary>
        public int Humidity { get; set; }
        
        /// <summary>
        /// Public property with pressure.
        /// </summary>
        public int Pressure { get; set; }

        /// <summary see cref="ChangingWeatherEventArgs">
        /// Constructor of class.
        /// </summary>
        public ChangingWeatherEventArgs()
        {
            sensor = new Random();

            Random();
        }

        #region Private methods
        private void Random()
        {
            Temperature = sensor.Next(-40, 40);
            Humidity = sensor.Next(0, 100);
            Pressure = sensor.Next(10, 40);
        }
        #endregion
    }
}
