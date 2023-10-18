using System;
using App6.Properties;

namespace App6
{
    public class ThermalPowerPlant : Stations
    {
        private double _contamination;
        private double _vaporGeneration;
        private double _operatingPressure;
        
        private readonly double MAXIMUM_CONTAMINATION = 75;  // Максимально допустимая суточная средняя концентрация (parts per billion, ppb)
        public static readonly double THERMAL_PRESSURE_LIMIT = 90; // Лимит рабочего давления (Бар);
        private readonly double VAPOR_MAXIMUM = 8000;               // Безопасный лимит производимого пара (кг/час);
        
        /// <summary>
        /// Генерация пара электростанцией для турбины;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double VaporGeneration
        {
            get => _vaporGeneration;
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Генерация пара не может быть отрицательной.");
                }
                if (value >= VAPOR_MAXIMUM)
                {
                    throw new IndexOutOfRangeException("Превышение генерации пара, это может навредить турбине станции.");
                }
                _vaporGeneration = value;
            }
        }
        
        /// <summary>
        /// Расположение станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double Contamination
        {
            get => _contamination;
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Уровень загрязнений не может быть отрицательным.");
                }
                // проверка на превышение уровня выделяемых загрызнений;
                if (value > MAXIMUM_CONTAMINATION)
                {
                    throw new IndexOutOfRangeException("Превышен допустимый уровень загрязнений.");
                }
                _contamination = value;
            }
        }

        /// <summary>
        /// Рабочее давление станции;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double OperatingPressure
        {
            get => _operatingPressure;
            set
            {
                if (value > THERMAL_PRESSURE_LIMIT)
                {
                    throw new IndexOutOfRangeException("Превышение рабочего давления.");
                }

                _operatingPressure = value;
            }
        }
        
        public ThermalPowerPlant(string name, double performanceKilowatt, double currentGeneration, int employeesCount, double stationContamination, int vaporGeneration, double stationPrice, double operatingPressure, string owner) : base(name, performanceKilowatt, currentGeneration, employeesCount, stationPrice, owner)
        {
            Contamination = stationContamination;
            VaporGeneration = vaporGeneration;
            OperatingPressure = operatingPressure;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Contamination (day): {Contamination}, Vapor Generation: {VaporGeneration}, Operating Pressure: {OperatingPressure}(Бар)";
        }
    }
}