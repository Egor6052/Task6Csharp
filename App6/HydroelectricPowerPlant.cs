using System;
using App6.Properties;

namespace App6
{
    public class HydroelectricPowerlant : Stations
    {
        private int _countOfCitiesAround;
        private int _amountOfReservoir;
        private double _operatingPressure;

        public static readonly int SITIES_AROUND = 50;  // Лимит городов, питаемых станцией;
        public static readonly double HYDROELECTRIC_PRESSURE_LIMIT = 100; // Лимит рабочего давления (Мегапаскалей);
        
        /// <summary>
        /// Количество водяных резервуаров около станции;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int AmountOfReservoir
        {
            get => _amountOfReservoir;
            set
            {
                // ограничений на количество водохранилищь не существует;
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Количество водяных резервуаров не может быть отрицательным.");
                }
                _amountOfReservoir = value;
            }
        }
        
        /// <summary>
        /// Количество зависящих от электростанции городов;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int CountOfCitiesAround
        {
            get => _countOfCitiesAround;
            set
            {
                // Городов, зависящих от станции не может быть более 50;
                if (value > SITIES_AROUND)
                {
                    throw new IndexOutOfRangeException("Станция не может питать такое количество городов.");
                }
                _countOfCitiesAround = value;
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
                if (value >= HYDROELECTRIC_PRESSURE_LIMIT)
                {
                    throw new IndexOutOfRangeException("Превышение рабочего давления.");
                }

                _operatingPressure = value;
            }
        }

        public HydroelectricPowerlant(string name, double performanceKilowatt, double currentGeneration, int employeesCount, int countOfCitiesAround, int amountOfReservoir, double stationPrice, double operatingPressure, string owner) : base(name, performanceKilowatt, currentGeneration, employeesCount, stationPrice, owner)
        {
            CountOfCitiesAround = countOfCitiesAround;
            AmountOfReservoir = amountOfReservoir;
            OperatingPressure = operatingPressure;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Count Of Cities Around: {CountOfCitiesAround}, Amount Of Reservoir: {AmountOfReservoir}, Operating Pressure: {OperatingPressure}(Мегапаскалей)";
        }
    }
}