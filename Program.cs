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
                OurParking.Add(Car);
            }

            int amount2 = OurParking.FreeSpace();
            
            //New part1 solution
            Car car2 = new Car();
            
            Console.WriteLine($"We have now only {amount2} parking lots\n");

            Console.WriteLine("We have this cars in the parking now:\n");
            foreach (var Car in OurParking)
            {
                //car2 below
                Console.WriteLine($"{car2.Color} {car2.Plate}");
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

        public IEnumerator GetEnumerator()
        {
            foreach (var car in _cars)
            {
                yield return car; //по очереди возвращаем машины с парковки
                Console.WriteLine(car.Color);
                Console.WriteLine(car.Plate);
            }
        }

    }

    
    public class Car // тут класс машин с Цветом и ГРЗ
    { 
    public string Color { get; set; }
    public string Plate { get; set; }

    }
}
