using System;
//СИТУАЦІЯ: ЇДЕ МАШИНА ПО АСВАЛЬТОВАНІЙ ДОРОЗІ, А КОЛИ ВОНА ЗАКІНЧУЄТЬСЯ, ТО ВОДІЙ ПЕРЕСІДАЄ НА ВЕЛОСИПЕД
//ТА РУХАЄТЬСЯ ВЕЛОСИПЕДОМ ПО СТЕЖЦІ
namespace AdapterExample
{
    interface ITransport
    {
        void Drive();
    }
    class Car : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car is going on the road");
        }
    }
    
    interface IBike
    {
        void Move();
    }

    
    class Bike : IBike
    {
        public void Move()
        {
            Console.WriteLine("Bike is going on trail");    
        }
    }
    
    class Driver
    {
       public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    class BikeToCarAdapter : ITransport
    {
        Bike bike;
        public BikeToCarAdapter(Bike bike)
        {
            this.bike = bike;
        }
        public void Drive()
        {
            bike.Move();
        }
    }


    public class Program
    {
        static void Main()
        {
            Driver driver = new Driver();
            Car car = new Car();
            driver.Travel(car);
            Bike bike = new Bike();
            ITransport bikeITransport = new BikeToCarAdapter(bike);
            driver.Travel(bikeITransport);
        }
    }
}