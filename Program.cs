using System;
using System.Collections;
using System.Collections.Generic;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking OurParking = new Parking();
            var OurCars = new List<Car>()
            {
                new Car() { Color = "green", Plate = "777" },
                new Car() { Color = "blue", Plate = "333" },
                new Car() { Color = "red", Plate = "555" },
            };
            Console.WriteLine("We have this cars:");
            foreach (var Car in OurCars)
            {
                Console.WriteLine($"{Car.Color} {Car.Plate}");
            }

            int amount = OurParking.FreeSpace();
            Console.WriteLine($"We have {amount} parking lots\n");
            Console.WriteLine("Lets park some cars");

            foreach (var Car in OurCars)
            {
                OurParking.Add(Car);
            }

            amount = OurParking.FreeSpace();
            Console.WriteLine($"We have now only {amount} parking lots\n");

            Console.WriteLine("работяги внури сварили желтую тачку\n");
            OurParking.AddMoreCars(); //тут внезапно в гараже работяги сами сварили желтую тачку

            amount = OurParking.FreeSpace();
            Console.WriteLine($"We have now only {amount} parking lots\n");

            Console.WriteLine("We have this cars in the parking now:\n");
            foreach (var Car in OurParking) // foreach должен итерировать по парковке, патамушта она наследует ienumerable
            {
                Console.WriteLine(Car);//????? 
            }
        }
    }
    public class Parking : IEnumerable
    {
        private List<Car> _cars = new List<Car>();
        private int _freeSpace = 10;

        public void Add(Car car)
        {
           _cars.Add(car);
            _freeSpace = _freeSpace - 1;
        }

        public int FreeSpace()
        {
            return _freeSpace;
        }



        public void AddMoreCars()
        {
            _cars.Add(new Car() { Color = "yellow", Plate = "SHIT" });
            _freeSpace = _freeSpace - 1;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var Cars in _cars)
            {
                yield return Cars.Color+" "+Cars.Plate;
            }
            //return _cars.GetEnumerator();

        }
    }

    
    public class Car // тут класс машин с Цветом и ГРЗ
    { 
    public string Color { get; set; }
    public string Plate { get; set; }

    }
}
