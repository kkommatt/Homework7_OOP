using System;
namespace CarFactory
{
    //абстрактний клас творця, який має абстрактний метод CarEngine, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Car CarEngine(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Car CarEngine(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new Toyota();
                //повертає об'єкт B, якщо type==2  
                case 2: return new BMW();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Car 
    { 
        public abstract void Info();
    } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class Toyota : Car 
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    public class BMW : Car 
    {
        public override void Info()
        {
            Console.WriteLine("BMW");
        }
    }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.CarEngine(i);
                Console.WriteLine("Where Car#{0}, engined {1} ", i, product.GetType());
                product.Info();
            }
            Console.ReadKey();
        }
    }
}
