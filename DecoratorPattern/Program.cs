using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage doubleMilkEspresso = new Espresso(BeverageSize.Large);
            doubleMilkEspresso = new Milk(doubleMilkEspresso);
            doubleMilkEspresso = new Milk(doubleMilkEspresso);
            Console.WriteLine(doubleMilkEspresso.Description);
            Console.WriteLine(doubleMilkEspresso.Cost());

			Beverage milkEspresso = new Espresso(BeverageSize.Small);
			milkEspresso = new Milk(milkEspresso);
			Console.WriteLine(milkEspresso.Description);
			Console.WriteLine(milkEspresso.Cost());

		}
    }
}
