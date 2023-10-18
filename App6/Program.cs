using System;
using App5;

namespace App6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HydroelectricPowerlant station1 = new HydroelectricPowerlant("HydroStation1", 10, 5000, 60, 4, 9, 12, 10, "Tim");
            HydroelectricPowerlant station2 = new HydroelectricPowerlant("HydroStation2", 8, 1000, 32, 5, 10, 48, 9, "Mask");
            ThermalPowerPlant station3 = new ThermalPowerPlant("ThermalStation1", 11, 8000, 54, 42, 5, 14, 80, "Mark");
            ThermalPowerPlant station4 = new ThermalPowerPlant("ThermalStation2", 9, 900, 38, 50, 12, 12, 80, "Billy");
            NuclearPowerPlant station5 = new NuclearPowerPlant("NuclearStation1", 14, 9000, 70, "Location1", 12, 50, 2, "Alex");
            NuclearPowerPlant station6 = new NuclearPowerPlant("NuclearStation2", 13,6000, 65,"Location2",9, 32, 3,"Jim");
            
            WeatherApp region1 = new WeatherForecastApp("Ukrain", "Celsies","Odessa",30);
            WeatherApp region2 = new WeatherForecastApp("Ukrain", "Celsies", "Lviv", 15);
            WeatherApp region3 = new WeatherForecastApp("Ukrain", "Celsies", "Kiev", 20);
            WeatherApp region4 = new WeatherForecastApp("Ukrane", "Celsies", "Kherson", 19);
            
            // Исходный массив регионов;
            RegionsArray regionsArray = new RegionsArray(region1, region2, region3, region4);
            
            Console.WriteLine("\nИсходный массив регионов: ");
            Console.Write(regionsArray.ToString());
            
            regionsArray.AddRegion(region1);
            Console.WriteLine("\n\nПосле добавления: ");
            Console.Write(regionsArray.ToString());
            
            regionsArray.EditRegion(2, region4);
            Console.WriteLine("\n\nПосле редактирования: ");
            Console.Write(regionsArray.ToString());
            
            regionsArray.RemoveRegion(4);
            Console.WriteLine("\n\nПосле удаления: ");
            Console.Write(regionsArray.ToString());
            
            
            // исходный массив stationsArray;
            // StationsArray stationsArray = new StationsArray(station1, station2, station3, station4);
            //
            // Console.WriteLine("Исходный масив:");
            // Console.WriteLine(stationsArray.ToString());
            //
            // stationsArray.AddStation(station5);
            // Console.WriteLine("После добавления:");
            // Console.WriteLine(stationsArray.ToString());
            //
            // Console.WriteLine("После редактирования:");
            // stationsArray.EditStation(3, station6);
            // Console.WriteLine(stationsArray.ToString());
            //
            // Console.WriteLine("После удаления:");
            // stationsArray.RemoveStation(0);
            // Console.WriteLine(stationsArray.ToString()) ;
        }
    }
}