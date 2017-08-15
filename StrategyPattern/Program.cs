using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat[] array = { new Cat(1,4), new Cat(2,3), new Cat(3,5) };

            Console.WriteLine("Sort by height:");
            foreach (var item in array)
            {
                item.comparer = new CatHeightComparer();
            }
			DataSorter.Sort(array);
            DataSorter.Print(array);

            Console.WriteLine("Sort by weight:");
            foreach (var item in array)
            {
                item.comparer = new CatWeightComparer();
            }
            DataSorter.Sort(array);
            DataSorter.Print(array);

            Console.WriteLine("Sort by BMI:");
            foreach (var item in array)
            {
                item.comparer = new CatBMIComparer();
            }
            DataSorter.Sort(array);
            DataSorter.Print(array);

            Console.ReadKey();
        } 
    }

}
