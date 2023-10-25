using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.AFP
{
    public interface IPizza //IproductA
    {
        string Eat();
    }

    class VegPizza : IPizza //ConcreateProduct1A
    {
        public string Eat()
        {
            return "Eating veg pizza";
        }
    }
    class NonVegPizza : IPizza //ConcreteProduct2A
    {
        public string Eat()
        {
            return "Eating non-veg pizza";
        }
    }

    public interface IBurger //IproductB
    {
        string Eat();
    }

    class VegBurger : IBurger //ConcreateProduct1B
    {
        public string Eat()
        {
            return "Eating veg burger";
        }
    }
    class NonVegBurger : IBurger//ConcreateProduct2B
    {
        public string Eat()
        {
            return "Eating non-veg burger";
        }
    }

    interface IChef //Factory
    {
        IPizza PreparePizza();
        IBurger PrepareBurger();
    }
    class VegChef : IChef
    {
        public IBurger PrepareBurger()
        {
            return new VegBurger();
        }

        public IPizza PreparePizza()
        {
            return new VegPizza();
        }
    }

    class NonVegChef : IChef
    {
        public IBurger PrepareBurger()
        {
            return new NonVegBurger();
        }

        public IPizza PreparePizza()
        {
            return new NonVegPizza();
        }
    }

    class Waiter
    {
        private IChef foodFactory;
        public Waiter(string preference)
        {
            if (preference == "Veg")
                foodFactory = new VegChef();
            else
                foodFactory = new NonVegChef();
        }
        public IPizza GetPizza()
        {
            return foodFactory.PreparePizza();
        }
        public IBurger GetBurger()
        {
            return foodFactory.PrepareBurger();
        }
    }
}
