namespace App5
{
    public abstract class WeatherApp : IWeatherApp
    {
        private readonly string _defaultLocation;

        public string DefaultLocation
        {
            get => _defaultLocation;
            init => _defaultLocation = value;
        }

        /// <summary>
        /// Конструктор локации по умолчанию;
        /// </summary>
        /// <param name="defaultLocation"></param>
        public WeatherApp(string defaultLocation)
        {
            DefaultLocation = defaultLocation;
        }
        
        public abstract void GetWeather(string location);
        public abstract void SetWeather(string units);

        public override string ToString()
        {
            return $"DefaultLocation: {DefaultLocation}, ";
        }
    }
}