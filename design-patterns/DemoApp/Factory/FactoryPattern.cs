namespace DemoApp.FP
{
    interface IPizzaChef //IFactory
    {
        IPizza PreparePizza();
    }

    class VegPizzaChef : IPizzaChef //ConcreteFactory1
    {
        public IPizza PreparePizza()
        {
            return new VegPizza();
        }
    }

    class NonVegPizzaChef : IPizzaChef //ConcreteFactory2
    {
        public IPizza PreparePizza()
        {
            return new NonVegPizza();
        }
    }

    public interface IPizza //IProduct
    {
        string Eat();
    }

    class VegPizza : IPizza //ConcreteProduct1 
    {
        public string Eat()
        {
            return "Eating Veg Pizza";
        }
    }

    class NonVegPizza : IPizza //ConcreteProduct2 
    {
        public string Eat()
        {
            return "Eating Non-Veg Pizza";
        }
    }

    class Waiter //Client
    {
        public IPizza GetPizza(string pizzaType)
        {
            IPizzaChef chef;
            switch (pizzaType)
            {
                case "NonVeg":
                    chef = new NonVegPizzaChef();
                    break;
                default:
                    chef = new VegPizzaChef();
                    break;
            }
            return chef.PreparePizza();
        }
    }
}
