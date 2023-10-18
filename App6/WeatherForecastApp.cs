using System;

namespace App5
{
    public class WeatherForecastApp : WeatherApp
    {
        private string _position;
        private string _units;
        private double _temperature;
        
        /// <summary>
        /// Проверка на правильность введенной геопозиции;
        /// </summary>
        /// <exception cref="Exception"></exception>
        public string Position
        {
            get => _position;
            set
            {
                if (value == "" && value == null)
                {
                    throw new Exception("Геопозиция не должна быть null или пустой строкой.");
                }
                
                _position = value;
            }
        }

        /// <summary>
        /// Проверка единиц измерения (название единиц измерения);
        /// </summary>
        /// <exception cref="Exception"></exception>
        public string Units
        {
            get => _units;
            set
            {
                if (value == "" && value == null)
                {
                    throw new Exception("Ед. измерения не должна быть null или пустой строкой.");
                }
                
                _units = value;
            }
        }

        /// <summary>
        /// Проверка и инициализация температуры;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Проверка на допустимые значения температуры</exception>
        public double Temperature
        {
            get => _temperature;
            set
            {
                if (value >= 100)
                {
                    throw new IndexOutOfRangeException("Значения температуры слишком высокие.");
                }

                if (value <= -100)
                {
                    throw new IndexOutOfRangeException("Значения температуры слишком низкие.");
                }

                _temperature = value;
            }
        }

        /// <summary>
        /// Конструктор для WeatherForecastApp;
        /// </summary>
        /// <param name="defaultLocation">Позщиция по умолчанию</param>
        /// <param name="units">Единица измерения</param>
        /// <param name="position">Заданная позиция</param>
        public WeatherForecastApp(string defaultLocation, string units, string position, double temperature) 
            : base(defaultLocation)
        {
            Position = position;
            Units = units;
            Temperature = temperature;
        }

        /// <summary>
        /// Реализация location из интерфейса IWeatherApp;
        /// </summary>
        /// <param name="location">Локация города</param>
        public override void GetWeather(string location)
        {
            Console.WriteLine($"City: {location}, Temperature {Temperature} in {Units}");
        }
        
        /// <summary>
        /// Инициализация метода newUnits из интерфейса IWeatherApp;
        /// </summary>
        /// <param name="newUnits">Единица измерения</param>
        public override void SetWeather(string newUnits)
        {
            Units = newUnits;
            Console.WriteLine($"Units set to {Units}.");
        }

        public override string ToString()
        {
            return $"{base.ToString()}Position: {Position}, Temperature: {Temperature}, Units: {Units}";
        }
        
    }
}