using System;
using App6.Properties;

namespace App6
{
    public class NuclearPowerPlant: Stations
    {
        private string _stationLocation;
        private int _radiationSafety;
        private int _numberOfReactors;
        
        public static readonly int RADIATION_LIMIT = 50;  // Максимальная допустимая доза радиации на станции. (Ед. измерения: Миллисиверт);
        public static readonly int REACTORS_LIMIT = 10;  // Максимальное безопасное количество реакторов;
        
        /// <summary>
        /// Радиационная безопасность на станции;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int RadiationSafety
        {
            get => _radiationSafety;
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Отрицательное число радиации быть не может.");
                }

                if (value > RADIATION_LIMIT)
                {
                    throw new IndexOutOfRangeException("Превышена норма радиации.");
                }
                _radiationSafety = value;
            }
        }

        /// <summary>
        /// Расположение станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Location
        {
            get => _stationLocation;
            set
            {
                // проверки корректность ввода данных о локации;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Локация не может быть пустой строкой или null.");
                }
                _stationLocation = value.Trim();
            }
        }

        /// <summary>
        /// Количество реакторов на ядерной электростанции;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int NumberOfReactors
        {
            get => _numberOfReactors;
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Отрицательное количество реакторов быть не может.");
                }

                if (value > REACTORS_LIMIT)
                {
                    throw new IndexOutOfRangeException("Большее количество реакторов может быть рисковано.");
                }
                _numberOfReactors = value;
            }
        }
        public NuclearPowerPlant(string name, double performanceKilowatt, double currentGeneration, int employeesCountCount, string stationLocation, int radiationSafety, double stationPrice, int numberOfReactors, string owner) : base(name, performanceKilowatt, currentGeneration, employeesCountCount, stationPrice, owner)
        {
            Location = stationLocation;
            RadiationSafety = radiationSafety;
            NumberOfReactors = numberOfReactors;
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}, Location: {Location}, Radiation Safety: {RadiationSafety}, Number Of Reactors: {NumberOfReactors}";
        }
    }
}