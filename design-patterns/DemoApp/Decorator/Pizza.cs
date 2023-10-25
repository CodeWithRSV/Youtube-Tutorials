using System;

namespace DemoApp
{
    public interface IPizza
    {
        void Prepare();
    }

    class BasePizza : IPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Pizza prepared");
        }
    }
    public abstract class PizzaDecorator : IPizza
    {
        private readonly IPizza _pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual void Prepare()
        {
            _pizza.Prepare();
        }
    }
    public class PepperoniPizza : PizzaDecorator
    {
        public PepperoniPizza(IPizza pizza) : base(pizza)
        {
        }
        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Adding Pepperoni Topping");
        }
    }
    public class OnionPizza : PizzaDecorator
    {
        public OnionPizza(IPizza pizza) : base(pizza)
        {
        }
        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Adding Onion Topping");
        }
    }
    public class CapsicumPizza : PizzaDecorator
    {
        public CapsicumPizza(IPizza pizza) : base(pizza)
        {
        }
        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Adding Capsicum Topping");
        }
    }
}