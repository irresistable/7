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
            Console.WriteLine("We have this cars:\n");
            foreach (var Car in OurCars)
            {
                Console.WriteLine($"{Car.Color} {Car.Plate}");
            }

            int amount = OurParking.FreeSpace();
            Console.WriteLine($"We have {amount} parking lots\n");
            Console.WriteLine("Lets park some cars\n");

            foreach (var Car in OurCars)
            {
            }



        

        }
    }
    public class Parking : IEnumerable
    {
        private List<Car> _cars = new List<Car>();
        private int _freeSpace = 10;

        public void Add(Car Car)
        {
            _cars.Add(Car);
            _freeSpace = _freeSpace - 1;
        }

        public int FreeSpace()
        {
            return _freeSpace;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var car in _cars)
            {
                yield return car; //по очереди возвращаем машины с парковки
            }
        }

    }

    
    public class Car // тут класс машин с Цветом и ГРЗ
    { 
    public string Color { get; set; }
    public string Plate { get; set; }

    }
}
