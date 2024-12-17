using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }
    public class MargheritaPizza : IPizza
    {
        public string GetDescription() => "Пицца";
        public double GetCost() => 350;
    }
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;
        public PizzaDecorator(IPizza pizza) => _pizza = pizza;
        public virtual string GetDescription() => _pizza.GetDescription();
        public virtual double GetCost() => _pizza.GetCost();
    }

    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }
        public override string GetDescription() => _pizza.GetDescription() + ", с сыром";
        public override double GetCost() => _pizza.GetCost() + 40;
    }

    public class MeatDecorator : PizzaDecorator
    {
        public MeatDecorator(IPizza pizza) : base(pizza) { }
        public override string GetDescription() => _pizza.GetDescription() + ", с мясом";
        public override double GetCost() => _pizza.GetCost() + 75;
    }

    public class VegetablesDecorator : PizzaDecorator
    {
        public VegetablesDecorator(IPizza pizza) : base(pizza) { }
        public override string GetDescription() => _pizza.GetDescription() + ", с овощами";
        public override double GetCost() => _pizza.GetCost() + 30;
    }

    public class SauceDecorator : PizzaDecorator
    {
        public SauceDecorator(IPizza pizza) : base(pizza) { }
        public override string GetDescription() => _pizza.GetDescription() + ", с соусом";
        public override double GetCost() => _pizza.GetCost() + 20;
    }
}
