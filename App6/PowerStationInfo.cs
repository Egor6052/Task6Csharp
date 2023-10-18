using System;
using System.Text.RegularExpressions;

namespace App6.Properties
{
    public class PowerStationInfo
    {
        private string _name;
        private double _performanceKilowatt;
        private double _currentGeneration;
        private double _stationPrice;
        private string _owner;

        public static readonly long MAX_VALUE_PERFORMANCE = 14000000000;    // Ед. измерений: КВт;
        public static readonly int  MAX_VALUE_CURRENT = 10000;              // Ед. измерений: Ампер;
        
        /// <summary>
        /// Название станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Name
        {
            get => _name;
            set
            {
                // проверка на нулевую строку или null;
                if (value == null && value == "")
                {
                    throw new ArgumentException("Имя не может быть пустой строкой или null.");
                }
                _name = value.Trim();
            }
        }

        /// <summary>
        /// Производительность станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double Performance
        {
            get => _performanceKilowatt;
            set
            {
                // проверка на нулевую производительность;
                if (value < 0)
                {
                    throw new ArgumentException("Производительноть не может быть отрицательной.");
                }

                // превышение рекомендуемой производительности;
                if (value > MAX_VALUE_PERFORMANCE)
                {
                    throw new ArgumentException(
                        "Производительность больше максимальной, что-то не так или у нас новый рекорд.");

                }

                _performanceKilowatt = value;
            }

        }

        /// <summary>
        /// Сколько станция генерирует тока;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double CurrentGeneration
        {
            get => _currentGeneration;
            set
            {
                // проверка на нулевую генерацию тока;
                if (value < 0)
                {
                    throw new ArgumentException("Генерация тока не может быть отрицательной.");
                }

                if (value > MAX_VALUE_CURRENT)
                {
                    throw new ArgumentException("Генерация тока выше допустимого значения.");
                }

                _currentGeneration = value;
            }
        }

        /// <summary>
        /// Цена станции;
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public double StationPrice
        {
            get => _stationPrice;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Цена не может быть отрицательной:");
                }

                _stationPrice = value;
            }
        }

        /// <summary>
        /// Имя владельца Станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Owner
        {
            get => _owner;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Имя владельца не может быть пустой строкой или null.");
                }

                // Проверка на наличие цифр или знаков препинания в имени владельца;
                if (Regex.IsMatch(value, @"[\d!@#$%^&*()_+{}\[\]:;<>,.?~\\]"))
                {
                    throw new ArgumentException("Имя владельца не должно содержать цифры или знаки препинания.");
                }
                _owner = value.Trim();
            }
        }

        public PowerStationInfo(string name, double performanceKilowatt, double currentGeneration, double stationPrice, string owner)
        {
            Name = name;
            Performance = performanceKilowatt;
            CurrentGeneration = currentGeneration;
            StationPrice = stationPrice;
            Owner = owner;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}, Performance: {Performance}, Current Generation: {CurrentGeneration}, Station Price: {StationPrice}$(million), Owner Station: {Owner} ";
        }
    }
}