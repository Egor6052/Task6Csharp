using System;
using System.Text;

namespace App6
{
    public class StationsArray
    {
        private Stations[] _stationsArray;
  
        public Stations[] PowerPlant => _stationsArray;
        public StationsArray(params Stations[] stationsArray)
        {
            _stationsArray = stationsArray;
        }
        
        /// <summary>
        /// Добавление станции в исходный массив;
        /// </summary>
        /// <param name="stations"></param>
        public void AddStation(Stations stations)
        {
            Array.Resize(ref _stationsArray, _stationsArray.Length + 1);
            _stationsArray[_stationsArray.Length - 1] = stations;
        }
        
        /// <summary>
        /// Удаление станции из массива;
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveStation(int index)
        {
            if (index >= 0 && index < _stationsArray.Length)
            {
                for (int i = index; i < _stationsArray.Length - 1; i++)
                {
                    _stationsArray[i] = _stationsArray[i + 1];
                }
                Array.Resize(ref _stationsArray, _stationsArray.Length - 1);
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс элемента выходит за пределы диапазона");
            }
        }
        
        /// <summary>
        /// Редактирование массива;
        /// </summary>
        /// <param name="index"></param>
        /// <param name="stations"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void EditStation(int index, Stations stations)
        {
            if (index >= 0 && index < _stationsArray.Length)
            {
                _stationsArray[index] = stations;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс элемента выходит за пределы диапазона");
            }
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var powerPlant in _stationsArray)
            {
                result.AppendLine(powerPlant.ToString());
            }
            return result.ToString();
        }
    }
}