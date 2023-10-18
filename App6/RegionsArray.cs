using System;
using System.Linq;

namespace App5
{
    public class RegionsArray
    {
        private WeatherApp[] _weatherApp;
        
        public RegionsArray(params WeatherApp[] weatherApp)
        {
            _weatherApp = weatherApp;
        }

        /// <summary>
        /// Добавление нового региона в массив;
        /// </summary>
        /// <param name="weatherApp"></param>
        /// <exception cref="ArgumentException">Выход за пределы массива</exception>
        public void AddRegion(WeatherApp weatherApp)
        {
            if (weatherApp != null)
            {
                Array.Resize(ref _weatherApp, _weatherApp.Length + 1);
                _weatherApp[_weatherApp.Length - 1] = weatherApp;
            }
            else
            {
                throw new ArgumentException("Выход за пределы массива");
            }
        }

        
        /// <summary>
        /// Удаление нового региона из массива;
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException">Индекс региона должен быть в массиве</exception>
        public void RemoveRegion(int index)
        {
            if (index < 0 || index >= _weatherApp.Length)
            {
                throw new IndexOutOfRangeException("Выход за пределы массива");
            }

            for (int i = index; i < _weatherApp.Length - 1; i++)
            {
                _weatherApp[i] = _weatherApp[i + 1];
            }
            Array.Resize(ref _weatherApp, _weatherApp.Length - 1);
        }

        /// <summary>
        ///  Изменение информации о данный региона в массиве регионов;
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newRegion"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <exception cref="AggregateException"></exception>
        public void EditRegion(int index, WeatherApp newRegion)
        {
            if (newRegion != null)
            {
                if (index < 0 || index >= _weatherApp.Length)
                {
                    throw new IndexOutOfRangeException("Региона с таким индексом нет в массиве.");
                }

                _weatherApp[index] = newRegion;
            }
            else
            {
                throw new AggregateException("Изменить массив не удалось.");
            }
        }

        /// <summary>
        /// Преобразование в строку;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _weatherApp.Select(weatherApp => weatherApp.ToString()));
        }

    }

    
}