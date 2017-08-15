using System;

namespace StrategyPattern
{
    public interface IComparable
    {
        int CompareTo(object o);
    }

    public interface IComparer
    {
        int Compare(object o1, object o2);
    }

    public class CatHeightComparer : IComparer
    {
        public int Compare(object o1, object o2)
        {
            if (o1 is null || !(o1 is Cat) || o2 is null || !(o2 is Cat))
            {
                throw new ArgumentNullException();
            }

            Cat cat1 = (Cat)o1;
            Cat cat2 = (Cat)o2;

            return cat1.Height - cat2.Height;
        }
    }

    public class CatWeightComparer : IComparer
    {
        public int Compare(object o1, object o2)
        {
            if (o1 is null || !(o1 is Cat) || o2 is null || !(o2 is Cat))
            {
                throw new ArgumentNullException();
            }

            Cat cat1 = (Cat)o1;
            Cat cat2 = (Cat)o2;

            return cat1.Weight - cat2.Weight;
        }
    }

    public class CatBMIComparer : IComparer
    {
        public int Compare(object o1, object o2)
        {
            if (o1 is null || !(o1 is Cat) || o2 is null || !(o2 is Cat))
            {
                throw new ArgumentNullException();
            }

            Cat cat1 = (Cat)o1;
            Cat cat2 = (Cat)o2;

            return (int)((((float)cat1.Weight) / Math.Pow(cat1.Height, 2)
                - ((float)cat2.Weight) / Math.Pow(cat2.Height, 2)) * 10);
        }
    }

    public class Cat : IComparable
    {
        public int Height { get; set; }
        public int Weight { get; set; }

        public IComparer comparer { get; set; }

        public Cat(int height, int weight)
        {
            Height = height;
            Weight = weight;
        }

        public int CompareTo(object o)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            return comparer.Compare(this, o);
        }

        public override string ToString()
        {
            return string.Format("[Cat: Height={0}, Weight={1}, BMI={2}]", 
                Height, Weight, (((float)Weight) / Math.Pow(Height, 2)).ToString("F1"));
        }
    }

    public class DataSorter
    {
        public DataSorter()
        {
        }

        //Bubble Sort
        internal static void Sort(IComparable[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        Swap(array, i, j);
                    }
                }
            }
        }

        private static void Swap(object[] array, int i, int j)
        {
            object tmp = array[j];
            array[j] = array[i];
            array[i] = tmp;
        }

        internal static void Print(object[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{" + array[i] + "}, ");
            }
            Console.Write("\n");
        }
    }
}
