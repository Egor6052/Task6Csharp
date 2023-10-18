using System;
using App6.Properties;

namespace App6
{
    public class Stations
    {
        private PowerStationInfo _powerStationInfo;
        private int _employeesCount;

        /// <summary>
        /// Число сотрудников;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int EmployeesCount
        {
            get => _employeesCount;
            // проверка на количество;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество электростанций не может быть отрицательное количество.");
                }
                _employeesCount = value;    
            }
            
        }

        public Stations(string name, double performanceKilowatt, double currentGeneration, int employeesCount, double stationPrice, string owner)
        {
            _powerStationInfo = new PowerStationInfo(name, performanceKilowatt, currentGeneration, stationPrice, owner);
            EmployeesCount = employeesCount;
        }
        
        public override string ToString()
        {
            return $"{_powerStationInfo}, Employees CountCount: {EmployeesCount}";
        }
    }
}