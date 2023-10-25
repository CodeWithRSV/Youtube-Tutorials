using System;

namespace DemoApp
{
    public interface IEngine
    {
        string Refill();
    }
    public abstract class IVehicle
    {
        protected IEngine engine;
        public IVehicle(IEngine engine)
        {
            this.engine = engine;
        }
        public abstract void Refill();
    }

    class Car : IVehicle
    {
        public Car(IEngine engine) : base(engine)
        {
        }

        public override void Refill()
        {
            Console.WriteLine("Car: " + engine.Refill());
        }
    }

    class Bike : IVehicle
    {
        public Bike(IEngine engine) : base(engine)
        {
        }

        public override void Refill()
        {
            Console.WriteLine("Bike: " + engine.Refill());
        }
    }
    class ElectricEngine : IEngine
    {
        public string Refill()
        {
            return "Charged engine to 100%";
        }
    }
    class PetrolEngine : IEngine
    {
        public string Refill()
        {
            return "Refueld engine to 5 liters";
        }
    }
}