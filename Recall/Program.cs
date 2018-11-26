using System;

namespace Recall
{
    public interface IPizza
    {
        string GetName();
        int GetCost();
    }

    public class ItalianPizza : IPizza
    {
        int IPizza.GetCost()
        {
            return 7;
        }

        string IPizza.GetName()
        {
            return "ItalianPizza";
        }
    }

    public class RussianPizza : IPizza
    {
        int IPizza.GetCost()
        {
            return 5;
        }

        string IPizza.GetName()
        {
            return "RussianPizza";
        }
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string GetName()
        {
            return _pizza.GetName();
        }

        public virtual int GetCost()
        {
            return _pizza.GetCost();
        }
    }

    public class ChesseDecorator : PizzaDecorator
    {
        public ChesseDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override int GetCost()
        {
            return 2 + base.GetCost();
        }

        public override string GetName()
        {
            return string.Format($"{base.GetName()}, chesse");
        }
    }

    public class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override int GetCost()
        {
            return 1 + base.GetCost();
        }

        public override string GetName()
        {
            return string.Format($"{base.GetName()}, tomato");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPizza rusPizza = new RussianPizza();

            IPizza decor = (new TomatoDecorator(new ChesseDecorator(new ChesseDecorator(rusPizza))));
            Console.WriteLine(decor.GetName());
            Console.WriteLine(decor.GetCost());
        }
    }
}
