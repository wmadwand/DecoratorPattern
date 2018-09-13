using System;

namespace Decorator01
{
    public interface IPizza
    {
        string GetName();
        int GetCost();
    }

    public class ItalianPizza : IPizza
    {
        public int GetCost()
        {
            return 30;
        }

        public string GetName()
        {
            return "Italian pizza";
        }
    }

    public class RussianPizza : IPizza
    {
        public int GetCost()
        {
            return 20;
        }

        public string GetName()
        {
            return "Russian pizza";
        }
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual int GetCost()
        {
            return _pizza.GetCost();
        }

        public virtual string GetName()
        {
            return _pizza.GetName();
        }
    }

    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override string GetName()
        {
            return string.Format($"{base.GetName()}, cheese");
        }

        public override int GetCost()
        {
            return base.GetCost() + 5;
        }
    }

    public class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override int GetCost()
        {
            return _pizza.GetCost() + 7;
        }

        public override string GetName()
        {
            return string.Format($"{_pizza.GetName()}, tomato");
        }
    }

    public class BoxDecorator : PizzaDecorator
    {
        private int _count;
        private string _boxName;
        private bool _isBoxed;

        public BoxDecorator(IPizza pizza, int boxCount) : base(pizza)
        {
            _count = boxCount;
        }

        public override int GetCost()
        {
            return base.GetCost() + 2 * _count;
        }

        public override string GetName()
        {
            return base.GetName();
        }

        public void Pack()
        {
            if (_isBoxed)
            {
                return;
            }

            _boxName = base.GetName();

            for (int i = 0; i < _count; i++)
            {
                _boxName = "[ " + _boxName + " ]";
            }

            _boxName.ToUpper();

            _isBoxed = true;
        }

        public string GetBoxedName()
        {
            return _isBoxed ? _boxName : "hasn't boxed yet";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPizza ital = new BoxDecorator(new TomatoDecorator(new CheeseDecorator(new ItalianPizza())), 3);
            Console.WriteLine(ital.GetName());
            Console.WriteLine(ital.GetCost());

            BoxDecorator italBox = (BoxDecorator)ital;
            italBox.Pack();
            Console.WriteLine(italBox.GetBoxedName());
        }
    }
}
